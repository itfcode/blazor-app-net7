using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Data.FilterHandlers
{
    public class NumericValueFilterHandler : FilterHandler<NumericValueFilter>
    {
        #region Constructions

        public NumericValueFilterHandler(NumericValueFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var property = GetProperty(item, Filter.PropertyName);
            var value = GetValue(Filter.Value, property.Type);

            Expression body;
            switch (Filter.MatchMode)
            {
                case NumericFilterMatchMode.LessThan:
                    body = Expression.LessThan(property, value);
                    break;
                case NumericFilterMatchMode.LessThanOrEquals:
                    body = Expression.LessThanOrEqual(property, value);
                    break;
                case NumericFilterMatchMode.GreaterThanOrEquals:
                    body = Expression.GreaterThanOrEqual(property, value);
                    break;
                case NumericFilterMatchMode.GreaterThan:
                    body = Expression.GreaterThan(property, value);
                    break;
                case NumericFilterMatchMode.Equals:
                    body = Expression.Equal(property, value);
                    break;
                default:
                    body = Expression.Equal(property, value);
                    break;
            }

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion
    }
}