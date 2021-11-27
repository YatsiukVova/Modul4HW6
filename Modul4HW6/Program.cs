using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modul4HW6.DataAccess;
using System.Linq;

namespace Modul4HW6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("settings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var connectionString = configuration.GetConnectionString("App");
            dbOptionsBuilder.UseSqlServer(connectionString, i => i.CommandTimeout(20));

            var appContext = new AppContext(dbOptionsBuilder.Options);
            appContext.Database.Migrate();


            appContext.SaveChanges();

            var appContextFactory = new AppContextFactory();
            using (appContext = appContextFactory.CreateDbContext(args))
            {
                //1
                /*
                var youngArtist = appContext.Artists.Max(a => a.DateOfBirth);
                var previouslyReleased = appContext.Songs
                    .Where(s => s.ReleasedDate < youngArtist)
                    .ToList();
                */
                //2
                var songsQuantity = appContext.Songs
                    .GroupBy(i => i.Genre.Title)
                    .Select(s => new
                    {
                        GenreTitle = s.Key,
                        CountSongs = s.Count()
                    })
                    .ToList();
                //3
                var youngArtists = appContext.Artists.Max(a => a.DateOfBirth);
                var Released = appContext.Songs
                    .Where(s => s.ReleasedDate < youngArtist)
                    .ToList();
            }
            
        }
    }
}
