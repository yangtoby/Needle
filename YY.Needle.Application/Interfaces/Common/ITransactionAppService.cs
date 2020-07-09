using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Data.Context.Interfaces;

namespace YY.Needle.Application.Interfaces.Common
{
    public interface ITransactionAppService<TContext>
         where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void Commit();
    }
}
