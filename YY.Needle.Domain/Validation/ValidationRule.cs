using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Interfaces.Specification;
using YY.Needle.Domain.Interfaces.Validation;

namespace YY.Needle.Domain.Validation
{

    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;

        public ValidationRule(ISpecification<TEntity> specificationRule, string errorMessage)
        {
            _specificationRule = specificationRule;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }
        public bool Valid(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}
