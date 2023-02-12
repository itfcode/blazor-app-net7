using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class RepositoryResolvingException : EntityRepositoryException
    {
        public RepositoryResolvingException(Exception innerException) : base(innerException) { }

        public RepositoryResolvingException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}