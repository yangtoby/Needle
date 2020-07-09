using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Data.Context;
using YY.Needle.Data.Context.Interfaces;

namespace YY.Needle.CrossCutting.InversionOfControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<LotteryContext>();
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind(typeof(IUnitOfWork<>)).To((typeof(UnitOfWork<>)));
        }
    }
}
