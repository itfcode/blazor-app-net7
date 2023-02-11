using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ITFCode.Core.Domain.Entities.Base.Interfaces;

namespace ITFCode.Core.Domain.EntityConfigurations.Base
{
    public abstract class EntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        protected EntityTypeBuilder<TEntity> _builder;

        protected virtual string TableName => typeof(TEntity).Name + "s";

        protected virtual void Configure()
        {
            if (_builder is null)
                throw new NullReferenceException(nameof(_builder));
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            _builder = builder;

            Configure();
        }
    }
}
