using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Validation;

namespace YY.Needle.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity>
        where TEntity : class
    {
        //TEntity Get(int id);
        //IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        ValidationResult Add(TEntity department);
        ValidationResult Update(TEntity department);
        ValidationResult Delete(TEntity entity);

      
    }
}
