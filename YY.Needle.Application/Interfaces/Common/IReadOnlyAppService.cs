using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Application.Interfaces.Common
{
    public interface IReadOnlyAppService<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
