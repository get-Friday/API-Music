using API_Music.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Music.DTOs
{
    public class PlaylistDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }
        public List<Music> Musics { get; set; }
    }
}
