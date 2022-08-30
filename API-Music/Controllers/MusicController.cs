using API_Music.Data;
using API_Music.DTOs;
using API_Music.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/musics")]
    public class MusicController : Controller
    {
        private readonly ProjectDbContext _context;
        public MusicController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Music>> Get(
            [FromQuery] string musicName,
            [FromQuery] string albumName,
            [FromQuery] string artistName
        )
        {
            var query = _context.Musics.AsQueryable();

            if (!string.IsNullOrEmpty(musicName))
            {
                query = query.Where(m => m.Name.Contains(musicName));
            }

            if (!string.IsNullOrEmpty(albumName))
            {
                query = query.Where(m => m.Album.Name.Contains(albumName));
            }

            if (!string.IsNullOrEmpty(artistName))
            {
                query = query.Where(m => m.Artist.Name.Contains(artistName));
            }

            return Ok(query.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Music> GetById(
            [FromRoute] int id    
        )
        {
            Music music = _context.Musics.Find(id);

            if (music == null) return NotFound();

            return Ok(music);
        }

        [HttpPost]
        public ActionResult<Music> Post(
            [FromBody] CreateMusicDTO newMusic
        )
        {
            Music music = new() 
            {
                Name = newMusic.Name,
                Duration = newMusic.Duration,
                ArtistId = newMusic.ArtistId,
                Artist = _context.Artists.Find(newMusic.ArtistId)
            };

            if (newMusic.AlbumId.HasValue)
            {
                music.AlbumId = newMusic.AlbumId;
                music.Album = _context.Albums.Find(newMusic.AlbumId);
            }

            _context.Musics.Add(music);
            _context.SaveChanges();

            return Created("api/musics", music.Id);
        }
        [HttpPut("{id}")]
        public ActionResult<Music> Put(
            [FromBody] CreateMusicDTO music,
            [FromRoute] int id
        )
        {
            Music m = _context.Musics.Find(id);

            if (m == null) return NotFound();

            m.Name = music.Name;
            m.Duration = music.Duration;
            m.ArtistId = music.ArtistId;
            m.Artist = _context.Artists.Find(music.ArtistId);

            if (music.AlbumId.HasValue)
            {
                m.AlbumId = music.AlbumId;
                m.Album = _context.Albums.Find(music.AlbumId);
            }

            return Created("api/musics", m.Id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(
            [FromRoute] int id    
        )
        {
            Music music = _context.Musics.Find(id);

            if (music == null) return NotFound();

            _context.Musics.Remove(music);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
