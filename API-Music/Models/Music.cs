using System.ComponentModel.DataAnnotations;

namespace API_Music.Models
{
    public class Music
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public Album Album { get; set; }
        [Required(ErrorMessage = "Artista é obrigatório.")]
        public Artist Artist { get; set; }
    }
}
