
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Application.Interfaces.Common;
using YY.Needle.Data.Context.Interfaces;
using YY.Needle.Domain.Validation;
using Microsoft.Practices.ServiceLocation;

namespace YY.Needle.Application
{

    public class AppService<TContext> : ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        public AppService()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; private set; }

        public virtual void BeginTransaction()
        {
            _uow = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
