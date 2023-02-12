using ITFCode.Core.Domain.Exceptions;
using ITFCode.Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Core.Domain.Repositories
{
    public abstract class UnitOfWorkCore<TDbContext> : IUnitOfWorkCore where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        // private IEntityRepository _entityRepository; 
        // public IEntityRepository EntityRepository => _entityRepository ??= ResolveRepository<IEntityRepository>();

        #region Constructors 

        public UnitOfWorkCore(TDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region IUnitOfWorkCore Implementation 

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new EntityCommitingException(ex);
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            var entries = _dbContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync(cancellationToken);
                        break;
                }
            }
        }

        #endregion

        #region Protected Methods 

        protected T ResolveRepository<T>() where T : class
        {
            try
            {
                return (T)_serviceProvider.GetService(typeof(T));
            }
            catch (Exception ex)
            {
                throw new RepositoryResolvingException(
                    message: $"Exception on resolving type of {typeof(T).FullName}",
                    innerException: ex);
            }
        }

        #endregion
    }
}