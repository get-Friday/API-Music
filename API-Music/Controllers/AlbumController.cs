using API_Music.DTOs;
using API_Music.Api.Repositories;
using API_Music.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : Controller
    {
        private readonly AlbumRepository _albumRepository;
        private readonly ArtistRepository _artistRepository;
        private readonly MusicRepository _musicRepository;
        public AlbumController(
            AlbumRepository repository,
            ArtistRepository artistRepository,
            MusicRepository musicRepository)
        {
            _albumRepository = repository;
            _artistRepository = artistRepository;
            _musicRepository = musicRepository;
        }

        [HttpGet]
        public ActionResult<List<Album>> Get()
        {
            return Ok(_albumRepository.Get());
        }

        [HttpGet("{albumId}/musics")]
        public ActionResult<Music> GetMusicByAlbumId(
            [FromRoute] int albumId    
        )
        {
            return Ok(_musicRepository.GetMusicFromAlbum(albumId));
        }

        [HttpPost]
        public ActionResult<Album> Post(
            [FromBody] AlbumDTO albumObject  
        )
        {
            Artist artist = _artistRepository.GetById(albumObject.ArtistId);

            Album album = new(
                albumObject.Name,
                albumObject.YearLaunch,
                albumObject.CoverUrl,
                artist
            );

            _albumRepository.Create(album);

            return Created("api/albums", album);
        }

        [HttpPut("{idAlbum}")]
        public ActionResult<Album> Put(
            [FromBody] AlbumDTO albumObject,
            [FromRoute] int albumId
        )
        {
            Artist artist = _artistRepository.GetById(albumObject.ArtistId);

            Album updatedAlbum = _albumRepository.Update(
                    albumId, 
                    new Album(
                        albumObject.Name,
                        albumObject.YearLaunch,
                        albumObject.CoverUrl,
                        artist
                    )
                );

            return Ok(updatedAlbum);
        }

        [HttpDelete("{idAlbum}")]
        public ActionResult Delete(
            [FromRoute] int albumId
        )
        {
            _albumRepository.Delete(albumId);

            return NoContent();
        }
    }
}
