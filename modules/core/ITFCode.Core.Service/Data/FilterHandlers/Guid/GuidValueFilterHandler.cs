using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Data.FilterHandlers
{
    internal class GuidValueFilterHandler : FilterHandler<GuidValueFilter>
    {
        #region Constructions

        public GuidValueFilterHandler(GuidValueFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var property = GetProperty(item, Filter.PropertyName);
            var value = GetValue(Filter.Value, property.Type);

            return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(property, value), item);
        }

        #endregion
    }
}
