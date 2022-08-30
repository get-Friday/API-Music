using System.ComponentModel.DataAnnotations;

namespace API_Music.DTOs
{
    public class CreateAlbumDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }
        [Range(1500, 3000, ErrorMessage = "Ano de lançamento precisa ser válido.")]
        public int YearLaunch { get; set; }
        public string CoverUrl { get; set; }
        [Required(ErrorMessage = "O artista é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do artista precisa ser válido")]
        public int ArtistId { get; set; }
        public List<MusicAlbumDTO> Musics { get; set; }
    }
}
