using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Interfaces.Service;
using YY.Needle.Domain.Interfaces.Service.Common;
using YY.Needle.Domain.Services;

namespace YY.Needle.CrossCutting.InversionOfControl.Modules
{

    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IService<>)).To(typeof(IService<>));

            Bind<ILottery3DService>().To<Lottery3DService>();
            Bind<IAverage3DService>().To<Average3DService>();
         
        }
    }
}
