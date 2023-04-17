using ITFCode.Core.DTO.FilterOptions.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers.Base
{
    public abstract class BaseRangeFilterHandler_Tests<TValue> 
    {
        public TFilter CreateFilter<TFilter>(string propName, TValue propValueFrom, TValue propValueTo) 
            where TFilter : FilterRangeOption<TValue>
        {
            var filter = (TFilter)(Activator.CreateInstance(typeof(TFilter)) ?? throw new NullReferenceException());

            filter.PropertyName = propName;
            filter.From = propValueFrom;
            filter.To = propValueTo;

            return filter;
        }
    }
}