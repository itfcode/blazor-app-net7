using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Core.Domain.EntityConfigurations.Base
{
    public abstract class EntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        #region Private & Protected Fields

        protected EntityTypeBuilder<TEntity> _builder;

        #endregion

        #region Protected Properties

        protected virtual string TableName => typeof(TEntity).Name + "s";

        protected EntityTypeBuilder<TEntity> Builder => _builder ?? throw new NullReferenceException("Builder not defined");

        #endregion

        #region Public Methods: IEntityTypeConfiguration Implementation

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            _builder = builder;

            Configure();
        }

        #endregion

        #region Protected Methods 

        protected virtual void Configure()
        {
            // do nothing
        }

        #endregion
    }
}