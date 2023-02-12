using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class EntityAddingException : EntityRepositoryException
    {
        public EntityAddingException(Exception innerException) : base(innerException) { }

        public EntityAddingException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}