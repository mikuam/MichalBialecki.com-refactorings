using MichalBialecki.com.Refactorings.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Users
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var user = _userService.GetUser(userId);

                return Json(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
