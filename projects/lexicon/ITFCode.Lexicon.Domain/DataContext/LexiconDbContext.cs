using ITFCode.Core.Domain.DataContext;
using ITFCode.Lexicon.Domain.DataContext.Interface;
using ITFCode.Lexicon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Domain.DataContext
{
    public class LexiconDbContext : ApplicationDbContextCore, ILexiconDbContext
    {
        public LexiconDbContext(DbContextOptions<LexiconDbContext> options)
            : base(options)
        {
        }

        public DbSet<LithuanianWord> LithuanianWord { get; set; }
        public DbSet<LithuanianVerbForm> LithuanianVerbForms { get; set; }
    }
}
