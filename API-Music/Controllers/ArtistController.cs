using API_Music.Api.Repositories;
using API_Music.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : Controller
    {
        private readonly ArtistRepository _artistRepository;
        public ArtistController(ArtistRepository repository)
        {
            _artistRepository = repository;
        }

        [HttpGet]
        public ActionResult<Artist> Get(
            [FromQuery] string name
        )
        {
            return Ok(_artistRepository.Get(name));
        }

        [HttpPost]
        public ActionResult<Artist> Post(
            [FromBody] Artist newArtist    
        )
        {
            return Created("/api/artists", _artistRepository.Create(newArtist));
        }

        [HttpPut("{idArtist}")]
        public ActionResult<Artist> Put(
            [FromBody] Artist artist,    
            [FromRoute] int idArtist
        )
        {
            return Ok(_artistRepository.Update(idArtist, artist));
        }

        [HttpDelete("{idArtist}")]
        public ActionResult Delete(
            [FromRoute] int idArtist
        )
        {
            _artistRepository.Delete(idArtist);

            return NoContent();
        }
    }
}
