using ITFCode.Core.Domain.Entities.Base;

namespace ITFCode.Lexicon.Domain.Entities.Base
{
    public class VerbForms<TWord> : Entity<int> where TWord : class  
    {
        public string PresentTense3rdPerson { get; set; }
        public string PastTense3rdPerson { get; set; }
        public string PresentTense1rdPerson { get; set; }
        public string PastTense1rdPerson { get; set; }
        public string FutureTense1rdPerson { get; set; }
        public int WordId { get; set; }
        public TWord Word { get; set; }   
    }
}