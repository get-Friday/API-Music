using System.ComponentModel.DataAnnotations;

namespace API_Music.DTOs
{
    public class EditAlbumDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }
        [Range(1500, 3000, ErrorMessage = "Ano de lançamento precisa ser válido.")]
        public int YearLaunch { get; set; }
        public string CoverUrl { get; set; }
    }
}
