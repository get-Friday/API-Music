using API_Music.Models;

namespace API_Music.Api.Repositories
{
    public class ArtistRepository
    {
        private static int indexId = 1;
        private static List<Artist> _artists = new();
        public Artist Create(Artist artist)
        {
            artist.Id = indexId++;
            _artists.Add(artist);

            return artist;
        }
        public Artist Update(int id, Artist artist)
        {
            Artist existingArtist = _artists
                .FirstOrDefault(a => a.Id == id);

            if (existingArtist == null) return null;

            existingArtist.Name = artist.Name;
            existingArtist.Alias = artist.Alias;
            existingArtist.PhotoUrl = artist.PhotoUrl;
            existingArtist.CountryFrom = artist.CountryFrom;

            return artist;
        }
        public void Delete(int id)
        {
            Artist existingArtist = _artists
                .FirstOrDefault(a => a.Id ==id);

            _artists.Remove(existingArtist);
        }
        public List<Artist> GetAll(string filter = null)
        {

            if (!String.IsNullOrEmpty(filter))
            {
                return _artists
                    .Where(a => a.Name.Contains(filter) || a.Alias.Contains(filter))
                    .ToList();
            }

            return _artists;
        }
    }
}
