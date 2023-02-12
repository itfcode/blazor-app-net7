using ITFCode.Core.Domain.Exceptions.Base;

namespace ITFCode.Core.Domain.Exceptions
{
    public class EntityNotFoundException : EntityRepositoryException
    {
        public EntityNotFoundException(object id, Type type) : base($"Entity '{type.Name}'(Id = {id}) not found") { }

        public EntityNotFoundException(object value, string paramName, Type type) : base($"Entity '{type.Name}'({paramName} = {value}) not found") { }

        public EntityNotFoundException(Type type) : base($"Entity '{type.Name}' not found for given condition") { }
    }
}