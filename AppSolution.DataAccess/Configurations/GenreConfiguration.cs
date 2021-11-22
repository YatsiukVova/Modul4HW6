using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HW6.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Modul4HW6.DataAccess.Configurations
{
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title");

            builder.HasData(new List<Genre>()
            {
                new Genre() { Id = 1, Title = "Title1"},
                new Genre() { Id = 2, Title = "Title2"},
                new Genre() { Id = 3, Title = "Title3"},
                new Genre() { Id = 4, Title = "Title4"},
                new Genre() { Id = 5, Title = "Title5"}
            });
        }
    }
}
