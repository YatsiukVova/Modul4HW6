using System;
using System.Collections.Generic;

namespace Modul4HW6.DataAccess.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<ArtistSong> ArtistSong { get; set; } = new List<ArtistSong>();
    }
}
