using ITFCode.Core.DTO.Entities.Base.Interfaces;
using ITFCode.Core.DTO.FilterOptions;

namespace ITFCode.Core.Service.Data.Interfaces
{
    public interface IReadDataService<TEntityDTO> : IDisposable
        where TEntityDTO : class, IEntityDTO
    {
        Task<TEntityDTO> Get(object key, CancellationToken cancellationToken = default);
        Task<TEntityDTO> Get(object[] keys, CancellationToken cancellationToken = default);
        Task<IList<TEntityDTO>> GetPage(QueryFilterOptions queryOptions, CancellationToken cancellationToken = default);
    }
}
