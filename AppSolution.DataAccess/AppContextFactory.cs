using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Modul4HW6
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("settings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var connectionString = configuration.GetConnectionString("App");
            dbOptionsBuilder.UseSqlServer(connectionString, i => i.CommandTimeout(120));

            return new AppContext(dbOptionsBuilder.Options);
        }
    }
}
