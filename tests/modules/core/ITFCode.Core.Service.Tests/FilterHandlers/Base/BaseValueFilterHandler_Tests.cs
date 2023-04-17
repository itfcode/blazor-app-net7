using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.DTO.FilterOptions.Base;

namespace ITFCode.Core.Service.Tests.FilterHandlers.Base
{
    public abstract class BaseValueFilterHandler_Tests<TValue> 
    {
        public TFilter CreateFilter<TFilter>(string propName, TValue propValue) 
            where TFilter : FilterValueOption<TValue>
        {
            var filter = (TFilter)(Activator.CreateInstance(typeof(TFilter)) ?? throw new NullReferenceException());

            filter.Value = propValue;
            filter.PropertyName = propName;

            return filter;
        }
    }
}