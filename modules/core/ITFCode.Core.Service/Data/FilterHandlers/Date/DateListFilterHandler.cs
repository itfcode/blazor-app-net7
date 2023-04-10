using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.Data.FilterHandlers
{
    public class DateListFilterHandler : FilterHandler<DateListFilter>
    {
        #region Constructions

        public DateListFilterHandler(DateListFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var value = Expression.Property(item, Filter.PropertyName);

            MethodInfo methodInfo;
            ConstantExpression list;

            if (value.Type == typeof(DateTime?))
            {
                methodInfo = typeof(List<DateTime?>).GetMethod("Contains", new Type[] { typeof(DateTime?) });
                list = Expression.Constant(Filter.Values.Select(x => (DateTime?)x).ToList());
            }
            else
            {
                methodInfo = typeof(List<DateTime>).GetMethod("Contains", new Type[] { typeof(DateTime) });
                list = Expression.Constant(Filter.Values);
            }

            var body = Expression.Call(list, methodInfo, value);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion
    }
}
