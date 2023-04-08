using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ITFCode.Core.Domain.DataContext
{
    public abstract class AppicationDdContextCoreFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : ApplicationDbContextCore
    {
        protected virtual string AppSettingsFile => "appsettings.json";
        protected virtual string ConnectionString => "DefaultDataContextConnection";

        public TDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            // GetById config from appsettings.json
            ConfigurationBuilder builder = new();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(AppSettingsFile);
            IConfigurationRoot config = builder.Build();

            // GetById connection string from appsettings.json

            string connectionString = config.GetConnectionString(ConnectionString) ?? string.Empty;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("ConnectionString not defined");
            }

            optionsBuilder.UseSqlServer(connectionString, opts =>
            {
                opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
            });

            return (TDbContext)Activator.CreateInstance(typeof(TDbContext), optionsBuilder.Options);
        }
    }
}
