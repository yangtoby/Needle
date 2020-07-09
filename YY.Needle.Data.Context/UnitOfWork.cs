
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Data.Context.Interfaces;
using Microsoft.Practices.ServiceLocation;


namespace YY.Needle.Data.Context
{

    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
        where TContext : IDbContext, new()
    {
        private readonly ContextManager<TContext> _contextManager =
            Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;

        private readonly IDbContext _dbContext;
        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = _contextManager.GetContext();

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
