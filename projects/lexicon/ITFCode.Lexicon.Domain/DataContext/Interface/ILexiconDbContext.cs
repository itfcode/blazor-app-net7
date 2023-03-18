using ITFCode.Lexicon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Lexicon.Domain.DataContext.Interface
{
    public interface ILexiconDbContext
    {
        DbSet<LithuanianWord> LithuanianWord { get; set; }

        DbSet<LithuanianVerb> LithuanianVerbs { get; set; }
    }
}