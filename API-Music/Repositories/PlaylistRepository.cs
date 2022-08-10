using API_Music.Models;

namespace API_Music.Repositories
{
    public class PlaylistRepository
    {
        private static int _indexId = 1;
        private static readonly List<Playlist> _playlists = new();
        public Playlist Create(Playlist playlist)
        {
            playlist.Id = _indexId++;
            _playlists.Add(playlist);

            return playlist;
        }
        public Playlist Update(int id, Playlist playlist)
        {
            Playlist existingPlaylist = _playlists
                .FirstOrDefault(playlist => playlist.Id == id);

            existingPlaylist.Name = playlist.Name;

            return playlist;
        }
        public void Delete(int id)
        {
            Playlist existingPlaylist = _playlists
                .FirstOrDefault(playlist => playlist.Id == id);

            _playlists.Remove(existingPlaylist);
        }
        public List<Playlist> Get()
        {
            return _playlists;
        }
        public Playlist Get(int id)
        {
            return _playlists.FirstOrDefault(playlist => playlist.Id == id);
        }
        public Playlist AddMusic(int id, Music music)
        {
            Playlist playlist = _playlists
                .FirstOrDefault(playlist => playlist.Id == id);

            playlist.Musics.Add(music);

            return playlist;
        }
    } 
}
