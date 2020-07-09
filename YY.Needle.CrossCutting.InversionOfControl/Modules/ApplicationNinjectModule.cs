using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Application;
using YY.Needle.Application.Interfaces;

namespace YY.Needle.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILottery3DAppService>().To<Lottery3DAppService>();
            Bind<IAverage3DAppService>().To<Average3DAppService>();
          
        }
    }
}
