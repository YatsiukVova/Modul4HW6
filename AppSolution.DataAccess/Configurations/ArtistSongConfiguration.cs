using Modul4HW6.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4HW6.DataAccess.Configurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Artist)
                .WithMany(y => y.ArtistSong)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Song)
                .WithMany(y => y.ArtistSong)
                .HasForeignKey(x => x.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
