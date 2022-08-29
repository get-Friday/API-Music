using API_Music.Data;
using API_Music.DTOs;
using API_Music.Models;
using API_Music.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : Controller
    {
        private readonly ProjectDbContext _context;
        public ArtistController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Artist>> Get(
            [FromQuery] string name    
        )
        {
            var query = _context.Artists.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));
            }

            if (!query.ToList().Any())
            {
                return NoContent();
            }

            return Ok(query.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> GetById(
            [FromRoute] int id    
        )
        {
            Artist query = _context.Artists
                .ToList()
                .Find(a => a.Id == id);

            if (query == null) return NotFound(new FailedReturnViewModel("Artista não encontrado."));

            return Ok(query);
        }

        [HttpPost]
        public ActionResult<Artist> Post(
            [FromBody] ArtistDTO newArtist    
        )
        {
            if (_context.Artists.Any(a => a.Name == newArtist.Name))
            {
                return BadRequest(new FailedReturnViewModel("Artista com esse nome já existente."));
            }

            Artist artist = new()
            {
                Name = newArtist.Name,
                Alias = newArtist.Alias,
                PhotoUrl = newArtist.PhotoUrl,
                CountryFrom = newArtist.CountryFrom
            };

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return Created("/api/artists", artist);
        }

        [HttpPut("{id}")]
        public ActionResult<Artist> Put(
            [FromBody] ArtistDTO artist,    
            [FromRoute] int id
        )
        {
            Artist query = _context.Artists.Find(id);

            if (query == null) return NotFound(new FailedReturnViewModel("Artista não encontrado"));

            query.Name = artist.Name;
            query.Alias = artist.Alias;
            query.PhotoUrl = artist.PhotoUrl;
            query.CountryFrom = artist.CountryFrom;

            _context.SaveChanges();

            return Ok(query);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(
            [FromRoute] int id
        )
        {
            Artist query = _context.Artists.Find(id);

            if (query == null) return NotFound(new FailedReturnViewModel("Artista não encontrado"));

            _context.Artists.Remove(query);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
