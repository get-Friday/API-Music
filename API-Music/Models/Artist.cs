using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace API_Music.Models
{
    public class Artist
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PhotoUrl { get; set; }
        public string CountryFrom { get; set; }

        public virtual List<Album> Albums { internal get; set; }
        public virtual List<Music> Musics { internal get; set; }
    }
}
