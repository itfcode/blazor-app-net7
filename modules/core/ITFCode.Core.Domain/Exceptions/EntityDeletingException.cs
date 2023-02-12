using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class EntityRemovingException : EntityRepositoryException
    {
        public EntityRemovingException(Exception innerException) : base(innerException) { }

        public EntityRemovingException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
