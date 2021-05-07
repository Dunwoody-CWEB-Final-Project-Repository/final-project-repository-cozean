using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Abstract;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Entities;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Concrete;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
            mykernel.Bind<IEpisodeRepository>().To<EFEpisodeRepository>();
        }
    }
}