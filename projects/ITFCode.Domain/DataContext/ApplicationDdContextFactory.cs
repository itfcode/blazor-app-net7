﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ITFCode.Domain.DataContext
{
    public class ApplicationDdContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // GetById config from appsettings.json
            ConfigurationBuilder builder = new();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // GetById connection string from appsettings.json

            string connectionString = config.GetConnectionString("ApplicationDataContextConnection") ?? string.Empty;

            if (string.IsNullOrWhiteSpace(connectionString)) 
            {
                throw new Exception("ConnectionString not defined");
            }

            optionsBuilder.UseSqlServer(connectionString, opts =>
            {
                opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
            });

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}