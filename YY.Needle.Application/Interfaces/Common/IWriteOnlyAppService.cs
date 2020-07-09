using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Validation;

namespace YY.Needle.Application.Interfaces.Common
{
    public interface IWriteOnlyAppService<in TEntity>
     where TEntity : class
    {
        ValidationResult Create(TEntity orderDetail);
        ValidationResult Update(TEntity orderDetail);
        ValidationResult Remove(TEntity orderDetail);
    }
}
