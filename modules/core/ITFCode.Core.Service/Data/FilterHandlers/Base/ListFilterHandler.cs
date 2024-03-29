﻿using ITFCode.Core.DTO.FilterOptions.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.Data.FilterHandlers.Base
{
    public abstract class ListFilterHandler<TFilter> : FilterHandler<TFilter>
        where TFilter : FilterOption
    {
        #region Constructions

        public ListFilterHandler(TFilter filter) : base(filter) { }

        #endregion

        #region Protected Methods 

        protected Expression<Func<TEntity, bool>> HandleList<TEntity, TValue>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var value = Expression.Property(item, Filter.PropertyName);

            MethodInfo? methodInfo;
            ConstantExpression list;

            var filterValues = (Filter as FilterListOption<TValue>)?.Values ?? throw new NullReferenceException("Cannot get list of values");

            if (filterValues.Count == 0)
                throw new ArgumentException("Filter value collection should be not empty!!!");

            var underlyingType = Nullable.GetUnderlyingType(value.Type);

            bool isNullable = underlyingType != null;

            //if (value.Type == typeof(TValue?))
            if (isNullable)
            {
                //methodInfo = value.Type.GetMethod("Contains", new Type[] { typeof(TValue?) });
                //list = Expression.Constant(filterValues.Select(x => (TValue?)x).ToList());
                methodInfo = typeof(List<TValue?>).GetMethod("Contains", new Type[] { typeof(TValue) });
                list = Expression.Constant(filterValues);
            }
            else
            {
                methodInfo = typeof(List<TValue>).GetMethod("Contains", new Type[] { typeof(TValue) });
                list = Expression.Constant(filterValues);
            }

            if (methodInfo is null)
                throw new NullReferenceException($"Method 'Contains' not defined for type List<{typeof(TValue)}>");

            var body = Expression.Call(list, methodInfo, value);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion
    }
}