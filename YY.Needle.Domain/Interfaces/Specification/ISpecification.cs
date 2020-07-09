using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.Interfaces.Specification
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
