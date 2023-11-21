using Loginet.TestTask.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.TestTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int Id)
        {
            return Ok(await _userService.GetUserById(Id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetUsers());
        }
    }
}