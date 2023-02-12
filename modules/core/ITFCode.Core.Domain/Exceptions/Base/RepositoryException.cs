namespace ITFCode.Core.Domain.Exceptions.Base
{
    public abstract class EntityRepositoryException : Exception
    {
        public EntityRepositoryException(string? message) : base(message) { }

        public EntityRepositoryException(string? message, Exception? innerException) : base(message, innerException) { }

        public EntityRepositoryException(Exception innerException) : base(innerException.Message, innerException) { }
    }
}
