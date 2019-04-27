using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MultiPlayerQuiz.Repository.Contracts;
using MultiPlayerQuiz.Repository.Models;

namespace MultiPlayerQuiz.Repository.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private Expression<Func<TEntity, bool>> RecordsById(int id) => RecordsByIdExpression(id);

        public async Task<List<TEntity>> All()
        {
            using (var context = new HackathonDBEntities2())
            {
                var dbSet = GetDbSet(context);
                return await dbSet.AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<TEntity>> AllBy(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new HackathonDBEntities2())
            {
                var dbSet = GetDbSet(context);
                return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
            }
        }

        public async Task<List<TEntity>> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new HackathonDBEntities2())
            {
                return await GetAllIncluding(context, includeProperties).ToListAsync();
            }
        }

        public async Task<List<TEntity>> AllByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new HackathonDBEntities2())
            {
                return await GetAllIncluding(context, includeProperties).Where(predicate).ToListAsync();
            }
        }

        public async Task<List<TEntity>> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new HackathonDBEntities2())
            {
                return await GetAllIncluding(context, includeProperties).Where(predicate).ToListAsync();
            }

        }

        public async Task<List<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new HackathonDBEntities2())
            {
                var dbSet = GetDbSet(context);
                return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
            }
        }

        public async Task<TEntity> FindByKey(int id)
        {
            using (var context = new HackathonDBEntities2())
            {
                var dbSet = GetDbSet(context);
                var data = dbSet.AsNoTracking().SingleOrDefault(RecordsById(id));
                return await Task.FromResult(data);
            }
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            using (var context = new HackathonDBEntities2())
            {
                var dbSet = GetDbSet(context);
                dbSet.Add(entity);
                context.SaveChanges();
            }

            return await Task.FromResult(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new HackathonDBEntities2())
            {
                var dbSet = GetDbSet(context);
                var dbEntity = dbSet.AsNoTracking().SingleOrDefault(RecordsById(GetProperty<int>(entity, "Id")));

                if (dbEntity == null)
                {
                    return null;
                }

                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

            return await Task.FromResult(entity);
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = new HackathonDBEntities2())
            {
                var dbSet = GetDbSet(context);
                var entity = dbSet.AsNoTracking().SingleOrDefault(RecordsById(id));

                if (entity == null)
                {
                    return false;
                }

                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }

            return await Task.FromResult(true);
        }

        private DbSet<TEntity> GetDbSet(HackathonDBEntities2 context)
        {
            return context.Set<TEntity>();
        }

        private IQueryable<TEntity> GetAllIncluding(HackathonDBEntities2 context, params Expression<Func<TEntity, object>>[] includeProperties)
        {

            var dbSet = GetDbSet(context);
            IQueryable<TEntity> queryable = dbSet.AsNoTracking();
            return includeProperties.Aggregate(queryable,
                (current, includeProperty) => current.Include(includeProperty));
        }


        private Expression<Func<TEntity, bool>> RecordsByIdExpression(int id)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }

        private void SetProperty<TValue>(TEntity entity, string property, TValue value)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty(property);
            var type = propertyInfo.PropertyType;

            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    value = default(TValue);
                }

                type = Nullable.GetUnderlyingType(type);
            }
            propertyInfo.SetValue(entity, Convert.ChangeType(value, type), null);
        }

        private TValue GetProperty<TValue>(TEntity entity, string property)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty(property);
            var value = propertyInfo.GetValue(entity);

            if (value is TValue)
            {
                return (TValue)value;
            }

            try
            {
                return (TValue)Convert.ChangeType(value, typeof(TValue));
            }
            catch (InvalidCastException)
            {
                return default(TValue);
            }
        }
    }
}

