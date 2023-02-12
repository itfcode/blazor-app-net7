using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class EntityUpdatingException : EntityRepositoryException
    {
        public EntityUpdatingException(Exception innerException) : base(innerException) { }

        public EntityUpdatingException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}