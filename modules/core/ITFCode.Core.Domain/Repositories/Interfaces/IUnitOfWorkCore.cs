namespace ITFCode.Core.Domain.Repositories.Interfaces
{
    public interface IUnitOfWorkCore
    {
        // IEntityRepository EntityRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
