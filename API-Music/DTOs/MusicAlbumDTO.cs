using System.ComponentModel.DataAnnotations;

namespace API_Music.DTOs
{
    public class MusicAlbumDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
