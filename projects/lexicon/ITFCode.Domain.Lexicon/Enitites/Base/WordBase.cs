using ITFCode.Core.Domain.Entities.Base;
using ITFCode.Domain.Entities.Lexicon.Enums;

namespace ITFCode.Domain.Lexicon.Enitites.Base
{
    public abstract class WordBase : Entity<string>
    {
        public string Value { get; set; }

        public PartsOfSpeech PartsOfSpeech { get; set; }

        public string TranslationRu { get; set; }

        public string TranslationUa { get; set; }
    }
}
