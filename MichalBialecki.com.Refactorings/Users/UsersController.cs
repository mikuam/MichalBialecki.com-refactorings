using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Users
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserDescriptionClient _userDescriptionClient;

        public UsersController(IUsersRepository usersRepository, IUserDescriptionClient userDescriptionClient)
        {
            _usersRepository = usersRepository;
            _userDescriptionClient = userDescriptionClient;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var user = await _usersRepository.Get(userId);
                var userDesctiption = await _userDescriptionClient.GetUserDescription(userId);

                return Json(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
