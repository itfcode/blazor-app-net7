using ITFCode.Core.Domain.Entities.Base.Interfaces;

namespace ITFCode.Core.Domain.Repositories.Interfaces
{
    public interface IEntityRepositoryCore<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Get(object key, CancellationToken cancellationToken = default);
        Task<TEntity> Get(object[] keys, CancellationToken cancellationToken = default);

        Task<TEntity> Find(object key, CancellationToken cancellationToken = default);
        Task<TEntity> Find(object[] keys, CancellationToken cancellationToken = default);

        Task<bool> Exists(object key, CancellationToken cancellationToken = default);
        Task<bool> Exists(object[] keys, CancellationToken cancellationToken = default);

        Task Update(object[] keyValues, Action<TEntity> updater, CancellationToken cancellationToken = default);
        Task UpdateRange(IEnumerable<object[]> keys, Action<TEntity> updater, CancellationToken cancellationToken = default);

        Task Add(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task Delete(object[] keys, CancellationToken cancellationToken = default);
    }
}
