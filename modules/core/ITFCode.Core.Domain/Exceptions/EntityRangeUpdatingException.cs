using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class EntityRangeUpdatingException : EntityRepositoryException
    {
        public EntityRangeUpdatingException(Exception innerException) : base(innerException) { }

        public EntityRangeUpdatingException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}