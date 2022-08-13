using System.ComponentModel.DataAnnotations;

namespace API_Music.DTOs
{
    public class MusicDTO
    {
        [Required(ErrorMessage = "O nome da música é requerido")]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
