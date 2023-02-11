using ITFCode.Core.Domain.Entities.Base.Interfaces;

namespace ITFCode.Core.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
    }

    public abstract class Entity<TKey> : IEntity<TKey> where TKey : IComparable
    {
        public TKey Id { get; set; }
    }
}