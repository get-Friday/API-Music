using API_Music.Api.Repositories;
using API_Music.Models;
using API_Music.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/playlists")]
    public class PlaylistController : Controller
    {
        private readonly PlaylistRepository _playlistRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly ArtistRepository _artistRepository;
        private readonly MusicRepository _musicRepository;
        public PlaylistController(
            PlaylistRepository repository,
            AlbumRepository albumRepository,
            ArtistRepository artistRepository,
            MusicRepository musicRepository)
        {
            _playlistRepository = repository;
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _musicRepository = musicRepository;
        }
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
    }
}
