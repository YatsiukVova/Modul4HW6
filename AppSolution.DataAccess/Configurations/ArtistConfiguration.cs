using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HW6.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Modul4HW6.DataAccess.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name");
            builder.Property(p => p.DateOfBirth).IsRequired().HasColumnName("DateOfBirth");
            builder.Property(p => p.Phone).HasColumnName("NumberOfPhone");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.InstagramUrl).HasColumnName("Inst");

            builder.HasData(new List<Artist>()
            { 
                new Artist() { Id = 1, Name = "Artist1", DateOfBirth = new DateTime(2015, 7, 20, 18, 30, 25), Phone = "+123456789", Email = "Email1@gmail.com", InstagramUrl = "https://inst1.com" },
                new Artist() { Id = 2, Name = "Artist2", DateOfBirth = new DateTime(1980, 6, 20, 18, 30, 25), Phone = "+789456123", Email = "Email1@gmail.com", InstagramUrl = "https://inst2.com" },
                new Artist() { Id = 3, Name = "Artist3", DateOfBirth = new DateTime(1990, 5, 20, 18, 30, 25), Phone = "+456123789", Email = "Email1@gmail.com", InstagramUrl = "https://inst3.com" },
                new Artist() { Id = 4, Name = "Artist4", DateOfBirth = new DateTime(2000, 4, 20, 18, 30, 25), Phone = "+123789456", Email = "Email1@gmail.com", InstagramUrl = "https://inst4.com" },
                new Artist() { Id = 5, Name = "Artist5", DateOfBirth = new DateTime(2010, 3, 20, 18, 30, 25), Phone = "+654987321", Email = "Email5@gmail.com", InstagramUrl = "https://inst5.com" }
            });
        }
    }
}
