using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Application.Interfaces.Common
{
    public interface IAppService<TEntity> : IWriteOnlyAppService<TEntity>, IDisposable
         where TEntity : class
    {
        //TEntity Get(int id, bool @readonly = false);
        //IEnumerable<TEntity> All(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

  
    }
}
