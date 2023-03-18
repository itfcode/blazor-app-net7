using ITFCode.Core.Domain.Entities.Base;
using ITFCode.Lexicon.Domain.Entities.Enums;

namespace ITFCode.Lexicon.Domain.Enitites.Base
{
    public abstract class WordBase : Entity<int>
    {
        public string Value { get; set; }

        public PartsOfSpeech PartsOfSpeech { get; set; }

        public string TranslationRu { get; set; }

        public string TranslationUa { get; set; }
    }
}
