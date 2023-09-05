using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.DTO.FilterOptions.Base;

namespace ITFCode.Core.DTO.Tests.FilterOptions
{
    public class FilterOptions_Tests
    {
        #region 'Bool'

        [Fact]
        public void BoolValueFilter_Test()
        {
            Assert.True(typeof(BoolValueFilter).IsSubclassOf(typeof(FilterValueOption<bool>)));
        }

        #endregion

        #region 'Date'

        [Fact]
        public void DateListFilter_Test()
        {
            var filterOptions = new DateListFilter();
            Assert.True(filterOptions is FilterListOption<DateTime>);
        }

        [Fact]
        public void DateRangeFilter_Test()
        {
            var filterOptions = new DateRangeFilter();
            Assert.True(filterOptions is FilterRangeOption<DateTime>);
        }

        [Fact]
        public void DateValueFilter_Test()
        {
            var filterOptions = new DateValueFilter();
            Assert.True(filterOptions is FilterValueOption<DateTime>);
        }

        #endregion

        #region 'Guid'

        [Fact]
        public void GuidListFilter_Test()
        {
            var filterOptions = new GuidListFilter();
            Assert.True(filterOptions is FilterListOption<Guid>);
        }

        [Fact]
        public void GuidValueFilter_Test()
        {
            var filterOptions = new GuidValueFilter();
            Assert.True(filterOptions is FilterValueOption<Guid>);
        }

        #endregion

        #region 'String'

        [Fact]
        public void StringListFilter_Test()
        {
            var filterOptions = new StringListFilter();
            Assert.True(filterOptions is FilterListOption<string>);
        }

        [Fact]
        public void StringValueFilter_Test()
        {
            var filterOptions = new StringValueFilter();
            Assert.True(filterOptions is FilterValueOption<string>);
        }

        #endregion

        #region 'Numeric'

        [Fact]
        public void NumericListFilter_Test()
        {
            var filterOptions = new NumericListFilter();
            Assert.True(filterOptions is FilterListOption<double>);
        }

        [Fact]
        public void NumericRangeFilter_Test()
        {
            var filterOptions = new NumericRangeFilter();
            Assert.True(filterOptions is FilterRangeOption<double>);
        }

        [Fact]
        public void NumericValueFilter_Test()
        {
            var filterOptions = new NumericValueFilter();
            Assert.True(filterOptions is FilterValueOption<double>);
        }

        #endregion
    }
}