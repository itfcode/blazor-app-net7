using ITFCode.Core.DTO.FilterOptions;
using ITFCode.Core.Service.Data.FilterHandlers.Base;
using System.Linq.Expressions;

namespace ITFCode.Core.Service.Data.FilterHandlers
{
    public class DateListFilterHandler : ListFilterHandler<DateListFilter>
    {
        #region Constructions

        public DateListFilterHandler(DateListFilter filter) : base(filter) { }

        #endregion

        #region Public Methods 

        public override Expression<Func<TEntity, bool>> Handle<TEntity>()
        {
            return HandleList<TEntity, DateTime>();
        }

        #endregion
    }
}
