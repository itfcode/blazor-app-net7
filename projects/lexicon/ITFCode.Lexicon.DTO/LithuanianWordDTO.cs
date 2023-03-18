using ITFCode.Lexicon.DTO.Base;

namespace ITFCode.Lexicon.DTO
{
    public class LithuanianWordDTO : LexiconDTO
    {
        public string Name { get; set; }

        public int PartsOfSpeech { get; set; }

        public int OriginalLanguage { get; set; }

        public string TranslationRu { get; set; }

        public string TranslationUa { get; set; }
    }
}