using ITFCode.Lexicon.Domain.Entities.Enums;

namespace ITFCode.Lexicon.Domain.Enitites.Base
{
    public abstract class WordBase : LexiconEntity
    {
        public string Name { get; set; }

        public PartOfSpeech PartsOfSpeech { get; set; }

        public virtual OriginalLanguage OriginalLanguage { get; set; }

        public string TranslationRu { get; set; }

        public string TranslationUa { get; set; }
    }
}
