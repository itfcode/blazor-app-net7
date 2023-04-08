using ITFCode.Domain.Entities.Lexicon.Enums;

namespace ITFCode.Domain.Entities.Lexicon.Base
{
    public abstract class Word
    {
        public string Source { get; set; }

        public OriginalLanguages OriginalLanguage { get; set; }

        public PartsOfSpeech PartOfSpeech { get; set; }

        public string TranslationRu { get; set; }

        public string TranslationUa { get; set; }


        public string? VerbFormId { get; set; }

        public VerbForm? VerbForm { get; set; }
    }
}