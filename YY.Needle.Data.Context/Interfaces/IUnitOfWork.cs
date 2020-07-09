using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Data.Context.Interfaces
{
    public interface IUnitOfWork<TContext>
         where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
