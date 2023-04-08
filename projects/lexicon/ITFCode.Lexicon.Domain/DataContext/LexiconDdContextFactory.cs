using ITFCode.Core.Domain.DataContext;

namespace ITFCode.Domain.DataContext
{
    public class LexiconDdContextFactory : AppicationDdContextCoreFactory<LexiconDbContext>
    {
        protected override string AppSettingsFile => "appsettings.json";
        protected override string ConnectionString => "LexiconDataContextConnection";

    }
}