using API_Music.Models;

namespace API_Music.Api.Repositories
{
    public class MusicRepository
    {
        private static int indexId = 1;
        private static readonly List<Music> _musics = new();
        public Music Create(Music music)
        {
            music.Id = indexId++;
            _musics.Add(music);

            return music;
        }
        public void Delete(int id, Music music)
        {
            Music existingMusic = _musics
                .FirstOrDefault(music => music.Id == id);

            _musics.Remove(existingMusic);
        }
        public Music Update(int id, Music music)
        {
            Music existingMusic = _musics
                .FirstOrDefault(music => music.Id == id);

            if (existingMusic == null) return null;

            existingMusic.Artist = music.Artist;
            existingMusic.Album = music.Album;
            existingMusic.Duration = music.Duration;
            existingMusic.Name = music.Name;

            return music;
        }
        public List<Music> Get()
        {
            return _musics;
        }
        public Music Get(int id)
        {
            return _musics.FirstOrDefault(music => music.Id == id);
        }
        public List<Music> GetMusicFromAlbum(int albumId)
        {
            return _musics
                .Where(m => m.Album != null)
                .Where(m => m.Album.Id == albumId)
                .ToList();
        }
    }
}
