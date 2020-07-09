using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Data.Repository.Dapper;
using YY.Needle.Data.Repository.EntityFramework;
using YY.Needle.Data.Repository.EntityFramework.Common;
using YY.Needle.Domain.Interfaces.Repository;
using YY.Needle.Domain.Interfaces.Repository.Common;
using YY.Needle.Domain.Interfaces.Repository.ReadOnly;

namespace YY.Needle.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));

            Bind<ILottery3DRepository>().To<Lottery3DRepository>();
            Bind<ILottery3DReadOnlyRepository>().To<Lottery3DDapperRepository>();
            //Bind<IReadOnlyRepository<Genre>>().To<GenreDapperRepository>();
            Bind<IAverage3DRepository>().To<Average3DRepository>();

        }
    }
}
