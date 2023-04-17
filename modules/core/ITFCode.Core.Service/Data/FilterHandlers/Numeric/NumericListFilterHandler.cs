using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers.Base;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ITFCode.Core.Service.Data.FilterHandlers
{
    public class NumericListFilterHandler : FilterHandler<NumericListFilter>
    {
        #region Constructions

        public NumericListFilterHandler(NumericListFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            var item = Expression.Parameter(typeof(TEntity), "item");
            var value = Expression.Property(item, Filter.PropertyName);

            var parameters = GetMethodAndList(value.Type);

            MethodInfo? methodInfo = parameters.Item1;
            ConstantExpression? list = parameters.Item2;

            if (methodInfo is null)
                throw new NullReferenceException($"Method List.Contains not defined for type {value.Type.Name}");

            var body = Expression.Call(list, methodInfo, value);

            return Expression.Lambda<Func<TEntity, bool>>(body, item);
        }

        #endregion

        #region Private Method

        public MethodInfo? GetMethod<T>()
        {
            return typeof(List<T>).GetMethod("Contains", new Type[] { typeof(T) });
        }

        public ConstantExpression? GetList<TValue>(Func<double, TValue> selector)
        {
            return Expression.Constant(Filter.Values.Select(selector).ToList());
        }

        private (MethodInfo?, ConstantExpression?) GetMethodAndList(Type type)
        {
            if (type == typeof(int)) return (GetMethod<int>(), GetList(x => (int)x));
            if (type == typeof(int?)) return (GetMethod<int?>(), GetList(x => (int?)x));
            if (type == typeof(uint)) return (GetMethod<int>(), GetList(x => (uint)x));
            if (type == typeof(uint?)) return (GetMethod<uint?>(), GetList(x => (uint?)x));

            if (type == typeof(long)) return (GetMethod<long>(), GetList(x => (long)x));
            if (type == typeof(long?)) return (GetMethod<long?>(), GetList(x => (long?)x));
            if (type == typeof(ulong)) return (GetMethod<ulong>(), GetList(x => (ulong)x));
            if (type == typeof(ulong?)) return (GetMethod<ulong?>(), GetList(x => (ulong?)x));

            if (type == typeof(byte)) return (GetMethod<byte>(), GetList(x => (byte)x));
            if (type == typeof(byte?)) return (GetMethod<byte?>(), GetList(x => (byte?)x));
            if (type == typeof(sbyte)) return (GetMethod<sbyte>(), GetList(x => (sbyte)x));
            if (type == typeof(sbyte?)) return (GetMethod<sbyte?>(), GetList(x => (sbyte?)x));

            if (type == typeof(short)) return (GetMethod<short>(), GetList<short>(x => (short)x));
            if (type == typeof(short?)) return (GetMethod<short?>(), GetList<short?>(x => (short?)x));
            if (type == typeof(ushort)) return (GetMethod<ushort>(), GetList<ushort>(x => (ushort)x));
            if (type == typeof(ushort?)) return (GetMethod<ushort?>(), GetList<ushort?>(x => (ushort?)x));

            if (type == typeof(float)) return (GetMethod<float>(), GetList<float>(x => (float)x));
            if (type == typeof(float?)) return (GetMethod<float?>(), GetList<float?>(x => (float?)x));

            if (type == typeof(double)) return (GetMethod<double>(), GetList<double>(x => (double)x));
            if (type == typeof(double?)) return (GetMethod<double?>(), GetList<double?>(x => (double?)x));

            if (type == typeof(decimal)) return (GetMethod<decimal>(), GetList<decimal>(x => (decimal)x));
            if (type == typeof(decimal?)) return (GetMethod<decimal?>(), GetList<decimal?>(x => (decimal?)x));

            throw new NotImplementedException();
        }

        #endregion
    }
}