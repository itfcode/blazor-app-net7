using ITFCode.Core.Domain.DataContext.Interfaces;
using ITFCode.Domain.Entities.Lexicon;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Domain.DataContext.Interfaces
{
    public interface IApplicationDbContext : IApplicationDbContextCore
    {
        #region Common

        #endregion

        #region Finance

        #endregion

        #region Health

        #endregion

        #region Lexicon

        DbSet<VocabularyRecord> VocabularyRecords { get; set; }

        #endregion
    }
}