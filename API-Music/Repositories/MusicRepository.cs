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
            Music music = _musics
                .FirstOrDefault(music => music.Id == id);

            return music;
        }
        public List<Music> GetWithFilter(string filter)
        {
            List<Music> list = _musics
                .Where(m => m.Name.Contains(filter) || m.Album.Name.Contains(filter) || m.Artist.Name.Contains(filter))
                .ToList();

            return list;
        }
    }
}
