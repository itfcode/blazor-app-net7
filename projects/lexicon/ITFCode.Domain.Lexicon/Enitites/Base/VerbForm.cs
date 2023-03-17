using ITFCode.Core.Domain.Entities.Base;

namespace ITFCode.Domain.Entities.Lexicon.Base
{
    public class VerbForms<TWord> : Entity<string> where TWord : class  
    {
        public string PresentTense3rdPerson { get; set; }
        public string PastTense3rdPerson { get; set; }
        public string PresentTense1rdPerson { get; set; }
        public string PastTense1rdPerson { get; set; }
        public string FutureTense1rdPerson { get; set; }
        public string WordId { get; set; }
        public TWord Word { get; set; }   
    }
}