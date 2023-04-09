using ITFCode.Core.DTO.Entities.Base.Interfaces;

namespace ITFCode.Core.Service.Data.Interfaces
{
    public interface IReadWriteDataService<TEntityDTO> :  IReadDataService<TEntityDTO>
        where TEntityDTO : class, IEntityDTO
    {
    }
}
