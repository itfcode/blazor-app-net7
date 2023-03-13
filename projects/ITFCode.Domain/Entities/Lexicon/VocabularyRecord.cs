using ITFCode.Core.Domain.Entities.Base;
using ITFCode.Domain.Entities.Lexicon.Enums;

namespace ITFCode.Domain.Entities.Lexicon
{
    public class VocabularyRecord : Entity<string>
    {
        public OriginalLanguages OriginalLanguage { get; set; }

        public PartsOfSpeech PartOfSpeech { get; set; }

        public string OriginalWord { get; set; }

        public string TranslationRU { get; set; }

        public string TranslationUA { get; set; }
    }
}