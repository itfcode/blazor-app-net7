using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class EntityCommitingException : EntityRepositoryException
    {
        public EntityCommitingException(Exception innerException) : base(innerException) { }

        public EntityCommitingException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}