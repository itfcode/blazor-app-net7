using ITFCode.Core.DTO.FilterOptions.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Data.FilterHandlers.Base
{
    public abstract class ValueFilterHandler<TFilter> : FilterHandler<TFilter>
        where TFilter : FilterOption
    {
        #region Constructions

        public ValueFilterHandler(TFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        protected Expression<Func<TEntity, bool>> HandleValue<TEntity, TValue>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var property = GetProperty(item, Filter.PropertyName);
            var value = GetValue((Filter as FilterValueOption<TValue>).Value, property.Type);

            return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(property, value), item);
        }

        #endregion
    }
}