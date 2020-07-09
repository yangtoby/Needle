using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Interfaces.Repository.Common;
using YY.Needle.Domain.Interfaces.Service.Common;
using YY.Needle.Domain.Interfaces.Validation;
using YY.Needle.Domain.Validation;

namespace YY.Needle.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity>
           where TEntity : class
    {
        #region Constructor

        private readonly IRepository<TEntity> _repository;
       
        private readonly ValidationResult _validationResult;

        public Service(
            IRepository<TEntity> repository
           )
        {
            _repository = repository;
           
            _validationResult = new ValidationResult();
        }

        #endregion

        #region Properties

        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }

      

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        #region Read Methods
    
        public virtual IEnumerable<TEntity> All(bool @readonly = false)
        {
            return _repository.All(@readonly);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.Find(predicate, @readonly);
        }

        #endregion

        #region CRUD Methods

        public virtual ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;


            _repository.Add(entity);
            return _validationResult;
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            _repository.Update(entity);
            return _validationResult;
        }

        public virtual ValidationResult Delete(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repository.Delete(entity);
            return _validationResult;
        }

        #endregion
    }
}
