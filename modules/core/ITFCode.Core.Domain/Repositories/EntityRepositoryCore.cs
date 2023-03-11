using ITFCode.Core.Domain.Entities.Base.Interfaces;
using ITFCode.Core.Domain.Exceptions;
using ITFCode.Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ITFCode.Core.Domain.Repositories
{
    public abstract class EntityRepositoryCore<TContext, TEntity> : IEntityRepositoryCore<TEntity>
        where TContext : DbContext
        where TEntity : class, IEntity
    {

        private readonly TContext _context;

        private readonly DbSet<TEntity> _dbSet;

        protected TContext Context => _context;

        protected DbSet<TEntity> DbSet => _dbSet;

        #region Constructors 

        public EntityRepositoryCore([NotNull] TContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region IEntityRepository Implementation

        public IQueryable<TEntity> GetAll() => GetQueryable();

        public async Task<TEntity> Get(object key, CancellationToken cancellationToken = default)
            => await Get(new object[] { key }, cancellationToken);

        public virtual async Task<TEntity> Get(object[] keys, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FindAsync(keys, cancellationToken);

            if (entity != null)
                return DetachEntity(entity);
            else
                throw new EntityNotFoundException(keys, typeof(TEntity));
        }

        public virtual async Task<TEntity> Find(object key, CancellationToken cancellationToken = default)
            => await Find(new object[] { key }, cancellationToken);

        public virtual async Task<TEntity> Find(object[] keys, CancellationToken cancellationToken = default)
            => await DbSet.FindAsync(keys, cancellationToken);

        public virtual async Task<bool> Exists(object key, CancellationToken cancellationToken = default)
            => await Exists(new object[] { key }, cancellationToken);

        public virtual async Task<bool> Exists(object[] keys, CancellationToken cancellationToken = default)
            => (await Find(keys, cancellationToken) is not null);

        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await DbSet.AddAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new EntityAddingException(ex);
            }
        }

        public virtual async Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                await DbSet.AddRangeAsync(entities, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new EntityAddingException(ex);
            }
        }

        public virtual async Task Update(object[] keys, Action<TEntity> updater, CancellationToken cancellationToken = default)
        {
            var entity = await Get(keys, cancellationToken);

            updater(entity);

            Update(entity);
        }

        public virtual async Task UpdateRange(IEnumerable<object[]> keys, Action<TEntity> updater, CancellationToken cancellationToken = default)
        {
            ValidateParam(keys, nameof(keys));

            var entities = new List<TEntity>();

            foreach (var keyValues in keys)
                entities.Add(await Get(keyValues, cancellationToken));

            UpdateRange(entities);
        }

        public virtual async Task<TEntity> UpdateAsync([NotNull] TEntity entity, bool commit = false, CancellationToken cancellationToken = default)
        {
            try
            {
                ValidateParam(entity, nameof(entity));

                var updated = DbSet.Update(AttachEntity(entity)).Entity;

                if (commit) await CommitChangesAsync(cancellationToken);

                return DetachEntity(updated);
            }
            catch (Exception ex)
            {
                throw new EntityUpdatingException(ex);
            }
        }

        public virtual async Task Delete(object[] keys, CancellationToken cancellationToken = default)
        {
            try
            {
                DbSet.Remove(await Get(keys, cancellationToken));
            }
            catch (Exception ex)
            {
                throw new EntityRemovingException(ex);
            }
        }

        #endregion

        #region Private & Protected Methods 

        protected virtual IQueryable<TEntity> GetQueryable() => DbSet.AsQueryable();

        protected virtual void ValidateParam<TParam>(TParam param, string paramName)
        {
            ArgumentNullException.ThrowIfNull(param, paramName);
        }

        public virtual async Task<int> CommitChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await Context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new EntityCommitingException(ex);
            }
        }

        protected TEntity AttachEntity(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);

            return entity;
        }

        protected void Update(TEntity entity)
        {
            try
            {
                if (entity is ITrackable trackable)
                    trackable.ModifiedAt = DateTime.Now;

                DbSet.Update(AttachEntity(entity));
            }
            catch (Exception ex)
            {
                throw new EntityUpdatingException(ex);
            }
        }

        protected void UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                DbSet.UpdateRange(AttachEntities(entities));
            }
            catch (Exception ex)
            {
                throw new EntityRangeUpdatingException(ex);
            }
        }

        protected IEnumerable<TEntity> AttachEntities(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);
            }

            return entities;
        }

        protected TEntity DetachEntity(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Detached)
                Context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        protected virtual void ValidateEntity(TEntity entity)
        {
            // validation rules should be coded for each entity 
        }

        #endregion

    }
}