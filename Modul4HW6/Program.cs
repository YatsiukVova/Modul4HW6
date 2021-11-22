using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Modul4HW6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("settings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var connectionString = configuration.GetConnectionString("App1");
            dbOptionsBuilder.UseSqlServer(connectionString,i=> i.CommandTimeout(20));

            var appContext = new AppContext(dbOptionsBuilder.Options);
            appContext.Database.Migrate();


            appContext.SaveChanges();

            var appContextFactory = new AppContextFactory();
            using (appContext = appContextFactory.CreateDbContext(args))
            {
                
            }

        }
    }
}
