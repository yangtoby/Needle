using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Validation;

namespace YY.Needle.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
