using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.Interfaces.Repository.Common
{
    public interface IRepository<TEntity> where TEntity :class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> All(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        IEnumerable<TEntity> GetPage(int pageSize, int pageIndex, out int total);
    }
}
