using System.ComponentModel.DataAnnotations;

namespace API_Music.Models
{
    public class Artist
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PhotoUrl { get; set; }
        public string CountryFrom { get; set; }
    }
}
