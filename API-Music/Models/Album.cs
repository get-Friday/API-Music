namespace API_Music.Models
{
    public class Album
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public int YearLaunch { get; set; }
        public string CoverUrl { get; set; }

        public int ArtistId { internal get; set; }
        public virtual Artist Artist { internal get; set; }
        public virtual List<Music> Musics { internal get; set; }
    }
}
