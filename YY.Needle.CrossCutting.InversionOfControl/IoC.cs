using CommonServiceLocator;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.CrossCutting.InversionOfControl.Modules;

namespace YY.Needle.CrossCutting.InversionOfControl
{

    public class IoC
    {
        public IKernel Kernel { get; private set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new InfrastructureNinjectModule(),
                new RepositoryNinjectModule(),
                new ApplicationNinjectModule());
        }
    }
}
