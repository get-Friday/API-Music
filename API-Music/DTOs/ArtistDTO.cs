using System.ComponentModel.DataAnnotations;

namespace API_Music.DTOs
{
    public class ArtistDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Alias { get; set; }
        public string PhotoUrl { get; set; }
        public string CountryFrom { get; set; }
    }
}
