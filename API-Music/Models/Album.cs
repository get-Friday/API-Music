using System.ComponentModel.DataAnnotations;

namespace API_Music.Models
{
    public class Album
    {
        public int Id { get; internal set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int YearLaunch { get; set; }
        public string CoverUrl { get; set; }
        public Artist Artist { get; set; }
        public List<Music> Musics { get; set; }
        public Album()
        {
        }
        public Album(string name, int yearLaunch, string coverUrl, Artist artist)
        {
            Name = name;
            YearLaunch = yearLaunch;
            CoverUrl = coverUrl;
            Artist = artist;    
        }
    }
}
