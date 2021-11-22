using System;
using System.Collections.Generic;

namespace Modul4HW6.DataAccess.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
