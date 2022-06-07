using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public double Time { get; set; }
        public int Popularity { get; set; }
        public double Price { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}

