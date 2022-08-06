using System.ComponentModel.DataAnnotations;

namespace API_Music.Models
{
    public class Artist
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage = "Nome do artista é obrigatório.")]
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PhotoUrl { get; set; }
        public string CountryFrom { get; set; }
    }
}
