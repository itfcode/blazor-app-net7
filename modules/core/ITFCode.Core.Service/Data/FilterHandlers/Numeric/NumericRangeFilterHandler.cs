using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Data.FilterHandlers
{
    public class NumericRangeFilterHandler : FilterHandler<NumericRangeFilter>
    {
        #region Constructors

        public NumericRangeFilterHandler(NumericRangeFilter filter) : base(filter) { }

        #endregion

        #region Public Methods

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");

            var property = GetProperty(item, Filter.PropertyName);

            var startValue = Filter.From;
            var finishValue = Filter.To;

            var valueFrom = GetValue(startValue, property.Type);
            var valueTo = GetValue(finishValue, property.Type);

            var conditionFrom = Expression.GreaterThanOrEqual(property, valueFrom);
            var conditionTo = Expression.LessThanOrEqual(property, valueTo);
            var conditionFromAndTo = Expression.AndAlso(conditionFrom, conditionTo);

            return Expression.Lambda<Func<TEntity, bool>>(conditionFromAndTo, item);
        }

        #endregion
    }
}