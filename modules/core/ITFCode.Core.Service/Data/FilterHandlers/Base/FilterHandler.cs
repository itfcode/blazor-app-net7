using System.Linq.Expressions;

namespace ITFCode.Core.Service.Data.FilterHandlers.Base
{
    public abstract class FilterHandler<TFilter> where TFilter : class
    {
        #region Private Fields

        private readonly TFilter _filter;

        #endregion

        #region Protected Properties 

        protected TFilter Filter => _filter ?? throw new NullReferenceException($"Filter not defined");

        #endregion

        #region Constructors

        public FilterHandler(TFilter filter)
        {
            ArgumentNullException.ThrowIfNull(filter, nameof(filter));

            _filter = filter;
        }

        #endregion

        #region Public Methods 

        public abstract Expression<Func<TEntity, bool>> Handle<TEntity>();

        #endregion

        #region Protected Methods 

        protected virtual Expression GetValue<T>(T value, Type propertyType)
        {
            return Expression.Convert(Expression.Constant(value), propertyType);
        }

        protected virtual Expression GetProperty(ParameterExpression item, string propertyName)
        {
            var parts = propertyName.Split('.');
            var property = parts.Aggregate<string, Expression>(item, Expression.Property);
            return property;
        }

        #endregion
    }
}