using ITFCode.Lexicon.Domain.Enitites.Base;
using ITFCode.Lexicon.Domain.Entities.Enums;

namespace ITFCode.Lexicon.Domain.Entities
{
    public class LithuanianWord : WordBase
    {
        public override OriginalLanguage OriginalLanguage { get; set; } = OriginalLanguage.Lithuanian;
    }
}
