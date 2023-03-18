using ITFCode.Lexicon.Domain.Entities;
using ITFCode.Lexicon.Domain.EntityConfigs.Base;
using ITFCode.Lexicon.Domain.EntityConfigs.InitialData;

namespace ITFCode.Lexicon.Domain.EntityConfigs
{
    public sealed class LithuanianWordConfig : LexiconEntityConfig<LithuanianWord> 
    {
        protected override void Configure()
        {
            base.Configure();

            _builder.HasData(LithuanianVocabulary.Verbs);
        }
    }
}