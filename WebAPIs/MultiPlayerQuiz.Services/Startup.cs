using MultiPlayerQuiz.Repository.Contracts;
using MultiPlayerQuiz.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace MultiPlayerQuiz.Services
{
    public static class Startup
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>), new HierarchicalLifetimeManager());
        }
    }
}
