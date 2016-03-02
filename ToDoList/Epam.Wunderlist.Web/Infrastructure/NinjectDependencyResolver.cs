using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Epam.Wunderlist.DependencyResolver;
using Ninject;

namespace Epam.Wunderlist.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel(new RevolverModule());
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}