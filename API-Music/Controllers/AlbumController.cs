using API_Music.Data;
using API_Music.DTOs;
using API_Music.Models;
using API_Music.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : Controller
    {
        protected readonly ProjectDbContext _context;
        public AlbumController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Album>> Get()
        {
            return Ok(_context.Albums);
        }

        
        [HttpGet("{id}/musics")]
        public ActionResult<List<Music>> GetMusicsByAlbumId(
            [FromRoute] int id
        )
        {
            Album query = _context.Albums.Find(id);

            if (query == null) return NotFound(new FailedReturnViewModel("Album não encontrado"));

            return Ok(query.Musics.ToList());
        }
        
        [HttpPost]
        public ActionResult<Album> Post(
            [FromBody] CreateAlbumDTO albumObject  
        )
        {
            Artist artist = _context.Artists.Find(albumObject.ArtistId);

            if (artist == null) return NotFound(new FailedReturnViewModel("Artista não encontrado"));

            Album album = new (){
                Name = albumObject.Name,
                YearLaunch = albumObject.YearLaunch,
                CoverUrl = albumObject.CoverUrl,
                Artist = artist
            };

            _context.Albums.Add(album);
            _context.SaveChanges();

            return Created("api/albums", album);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Album> Put(
            [FromBody] EditAlbumDTO albumObject,
            [FromRoute] int id
        )
        {
            Album album = _context.Albums.Find(id);

            if (album == null) return NotFound(new FailedReturnViewModel("Album não encontrado"));

            album.Name = albumObject.Name;
            album.YearLaunch = albumObject.YearLaunch;
            album.CoverUrl = albumObject.CoverUrl;

            _context.SaveChanges();

            return Ok(album);
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(
            [FromRoute] int id
        )
        {
            Album query = _context.Albums.Find(id);

            if (query == null) return NotFound(new FailedReturnViewModel("Album não encontrado"));

            _context.Albums.Remove(query);

            return NoContent();
        }
    }
}
