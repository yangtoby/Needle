
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Data.Context;
using YY.Needle.Data.Context.Interfaces;
using YY.Needle.Domain.Interfaces.Repository.Common;

namespace YY.Needle.Data.Repository.EntityFramework.Common
{

    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        public Repository()
        {
            var contextManager = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IContextManager<LotteryContext>>()
                as ContextManager<LotteryContext>;

            _dbContext = contextManager.GetContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected IDbContext Context
        {
            get { return _dbContext; }
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> All(bool @readonly = false)
        {
            return @readonly
                ? DbSet.AsNoTracking().ToList()
                : DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly
                ? DbSet.Where(predicate).AsNoTracking()
                : DbSet.Where(predicate);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        public IEnumerable<TEntity> GetPage(int pageSize, int pageIndex, out int total)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
