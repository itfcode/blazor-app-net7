using ITFCode.Core.Domain.DataContext;
using ITFCode.Domain.DataContext.Interfaces;
using ITFCode.Domain.Entities.Lexicon;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Domain.DataContext
{
    public class ApplicationDbContext : ApplicationDbContextCore, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VocabularyRecord> VocabularyRecords { get; set; }
    }
}
