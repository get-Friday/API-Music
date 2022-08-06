using API_Music.Models;

namespace API_Music.Api.Repositories
{
    public class AlbumRepository
    {
        private static int indexId = 1;
        private static readonly List<Album> _albums = new();
        public Album Create(Album album)
        {
            album.Id = indexId++;
            _albums.Add(album);

            return album;
        }
        public void Delete(int id)
        {
            Album existingAlbum = _albums
                .FirstOrDefault(a => a.Id == id);

            _albums.Remove(existingAlbum);
        }
        public Album Update(int id, Album album)
        {
            Album existingAlbum = _albums
                .FirstOrDefault(a => a.Id == id);

            existingAlbum.Artist = album.Artist;
            existingAlbum.CoverUrl = album.CoverUrl;
            existingAlbum.YearLaunch = album.YearLaunch;
            existingAlbum.Name = album.Name;

            return album;
        }
        public List<Album> Get()
        {
            return _albums;
        }
        public Album Get(int id)
        {
            return _albums.FirstOrDefault(a => a.Id == id);
        }
    }
}
