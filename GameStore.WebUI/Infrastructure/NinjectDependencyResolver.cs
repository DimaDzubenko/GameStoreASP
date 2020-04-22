using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GameStore.WebUI.Infrastructure
{
    /// <summary>
    /// Клас внедрения зависимостей
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernelParam"></param>
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        /// <summary>
        /// Добавить зависомость
        /// </summary>
        private void AddBindings()
        {
            kernel.Bind<IGameRepository>().To<EFGameRepository>();
        }
    }
}