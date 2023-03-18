using ITFCode.Lexicon.DTO.Base;

namespace ITFCode.Lexicon.DTO
{
    public class LithuanianVerbFormDTO : LexiconDTO
    {
        public string PresentTense3rdPerson { get; set; }
        public string PastTense3rdPerson { get; set; }
        public string PresentTense1rdPerson { get; set; }
        public string PastTense1rdPerson { get; set; }
        public string FutureTense1rdPerson { get; set; }
        public int WordId { get; set; }
    }
}