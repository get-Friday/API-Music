using System.ComponentModel.DataAnnotations;

namespace API_Music.Models
{
    public class Playlist
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public List<Music> Musics { get; set; }
    }
}
