using Loginet.TestTask.Api.Interfaces;
using Loginet.TestTask.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.TestTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AlbumsController : Controller
    {
        private IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _albumService.GetAlbumById(Id));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _albumService.GetAlbums());
        }

        [HttpGet]
        public async Task<IActionResult> GetByUser(int Id)
        {
            return Ok(await _albumService.GetUserAlbums(Id));
        }
    }
}
