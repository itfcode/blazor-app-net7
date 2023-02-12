using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class EntityRangeDeletingException : EntityRepositoryException
    {
        public EntityRangeDeletingException(Exception innerException) : base(innerException) { }

        public EntityRangeDeletingException(string message, Exception? innerException) : base(message, innerException) { }
    }
}