using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers;
using ITFCode.Core.Service.Tests.FilterHandlers.Base;
using System;
using static ITFCode.Core.Service.Tests.TestData;

namespace ITFCode.Core.Service.Tests.FilterHandlers
{
    public class GuidListFilterHandler_Tests : BaseListFilterHandler_Tests<Guid>
    {

        [Fact]
        public void Constructor_Throw_If_Parameter_Is_Null() 
        {
            Assert.Throws<ArgumentNullException>(() => new GuidListFilterHandler(null));
        }

        [Theory]
        [MemberData(nameof(GetGuidTestLists))]
        public void Handle_Should_Be_Equal(string propName, IEnumerable<Guid> propValues, int itemCount)
        {
            var filter = CreateFilter<GuidListFilter>(propValues.Select(x => x).ToList(), propName);
            var expression = new GuidListFilterHandler(filter).Handle<SimpeItem>();
            var res = TestData.Items.Where(expression).ToList();

            Assert.Equal(itemCount, res.Count);
        }

        public static IEnumerable<object[]> GetGuidTestLists()
        {
            yield return new object[] { "GuidProp", new Guid[] { }, 0 };
            yield return new object[] { "GuidProp", new Guid[] { Guid1 }, 1 };
            yield return new object[] { "GuidProp", new Guid[] { Guid1, Guid2 }, 2 };
            yield return new object[] { "GuidProp", new Guid[] { Guid1, Guid2, Guid3 }, 3 };

            yield return new object[] { "GuidNullableProp", new Guid[] { }, 0 };
            yield return new object[] { "GuidNullableProp", new Guid[] { Guid1 }, 1 };
            yield return new object[] { "GuidNullableProp", new Guid[] { Guid1, Guid2 }, 2 };
            yield return new object[] { "GuidNullableProp", new Guid[] { Guid1, Guid2, Guid3 }, 3 };
        }
    }
}