using API_Music.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Music.DTOs
{
    public class CreateMusicDTO
    {
        [Required(ErrorMessage = "O nome da música é requerido")]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int? AlbumId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "O artista é obrigatório.")]
        public int ArtistId { get; set; }
    }
}
