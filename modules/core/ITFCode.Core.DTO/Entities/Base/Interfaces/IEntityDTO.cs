namespace ITFCode.Core.DTO.Entities.Base.Interfaces
{
    public interface IEntityDTO
    {
    }

    public interface IEntityDTO<TKey> : IEntityDTO where TKey : IComparable
    {
        public TKey Id { get; set; }
    }
}