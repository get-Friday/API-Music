using API_Music.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/playlists")]
    public class PlaylistController : Controller
    {
        /*
        [HttpGet]
        public ActionResult<List<Playlist>> Get()
        {
            return Ok(_playlistRepository.Get());
        }
        [HttpPost]
        public ActionResult<Playlist> Post(
            [FromBody] Playlist playlist
        )
        {
            _playlistRepository.Create(playlist);

            return Created("api/playlists", playlist);
        }
        [HttpPut("{idPlaylist}")]
        public ActionResult<Playlist> Put(
            [FromRoute] int id,
            [FromBody] Playlist playlist
        )
        {
            _playlistRepository.Update(id, playlist);

            return Ok(playlist);
        }
        [HttpDelete("{idPlaylist}")]
        public ActionResult Delete(
            [FromRoute] int id    
        )
        {
            _playlistRepository.Delete(id);

            return NoContent();
        }
        */
    }
}
