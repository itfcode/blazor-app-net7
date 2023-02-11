using ITFCode.Core.DTO.Entities.Base.Interfaces;

namespace ITFCode.Core.DTO.Entities.Base
{
    public abstract class EntityDTO : IEntityDTO
    {
    }

    public abstract class EntityDTO<TKey> : IEntityDTO<TKey> where TKey : IComparable
    {
        public TKey Id { get; set; }
    }
}
