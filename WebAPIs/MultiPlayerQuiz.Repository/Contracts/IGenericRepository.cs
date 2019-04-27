using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayerQuiz.Repository.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> All();

        Task<List<TEntity>> AllBy(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> AllByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> FindBy(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FindByKey(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<bool> Delete(int id);
    }
}
