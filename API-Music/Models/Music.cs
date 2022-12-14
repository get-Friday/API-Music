using System.ComponentModel.DataAnnotations;

namespace API_Music.Models
{
    public class Music
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public int? AlbumId { get; set; }
        public int ArtistId { get; set; }
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
