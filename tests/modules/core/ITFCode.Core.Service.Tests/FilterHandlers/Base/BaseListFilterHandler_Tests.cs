using ITFCode.Core.DTO.FilterOptions.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers.Base
{
    public abstract class BaseListFilterHandler_Tests<TValue> 
    {
        public TFilter CreateFilter<TFilter>(IEnumerable<TValue> propValues, string propName) 
            where TFilter : FilterListOption<TValue>
        {
            var filter = (TFilter)(Activator.CreateInstance(typeof(TFilter)) ?? throw new NullReferenceException());

            filter.Values = new List<TValue>(propValues);
            filter.PropertyName = propName;

            return filter;
        }
    }
}