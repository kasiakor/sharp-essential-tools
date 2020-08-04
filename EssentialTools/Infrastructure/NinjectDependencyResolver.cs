using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;


namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        //NinjectDependencyResolver class implements the IDependencyResolver interface
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        //MVC Framework will call the GetService or GetServices methods when it needs an instance of a class to service an incoming request.
        public object GetService(Type serviceType)
        {

            //null when there is no suitable binding 
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            //supports multiple bindings for a single type
            return kernel.GetAll(serviceType);
        }
        //binding
        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculatorInterface>();
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();

        }
    }
}
