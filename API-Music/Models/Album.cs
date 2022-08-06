using System.ComponentModel.DataAnnotations;

namespace API_Music.Models
{
    public class Album
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public int YearLaunch { get; set; }
        public string CoverUrl { get; set; }
        [Required(ErrorMessage = "Artista é obrigatório")]
        public Artist Artist { get; set; }
    }
}
