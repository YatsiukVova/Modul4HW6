using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HW6.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Modul4HW6.DataAccess.Configurations
{
    class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title");
            builder.Property(p => p.Duration).IsRequired().HasColumnName("Duration");
            builder.Property(p => p.ReleasedDate).IsRequired().HasColumnName("ReleaseDate");

            builder.HasOne(g => g.Genre)
               .WithMany(s => s.Songs)
               .HasForeignKey(g => g.Id)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Song>()
            {
                new Song(){ Id = 1, Title = "Butter", Duration = 2.5M, ReleasedDate = new DateTime(2015, 7, 20, 18, 00, 00) },
                new Song(){ Id = 2, Title = "Leave the door open", Duration = 2.3M, ReleasedDate = new DateTime(1976, 7, 20, 18, 00, 00) },
                new Song(){ Id = 3, Title = "Kiss me more", Duration = 2.0M, ReleasedDate = new DateTime(2001, 7, 20, 18, 00, 00) },
                new Song(){ Id = 4, Title = "Save your tears", Duration = 1.5M, ReleasedDate = new DateTime(2014, 7, 20, 18, 00, 00) },
                new Song(){ Id = 5, Title = "good 4 u", Duration = 1.8M, ReleasedDate = new DateTime(2020, 7, 20, 18, 00, 00) }
            });
        }
        
    }
}
