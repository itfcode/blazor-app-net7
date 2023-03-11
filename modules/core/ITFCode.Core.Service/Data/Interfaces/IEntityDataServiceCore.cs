using ITFCode.Core.DTO.Entities.Base.Interfaces;

namespace ITFCode.Core.Service.Data.Base.Interfaces
{
    public interface IEntityDataServiceCore<TEntityDTO> : IDisposable
        where TEntityDTO : class, IEntityDTO
    {
        Task<TEntityDTO> Get(object[] keys, CancellationToken cancellationToken = default);
    }
}
