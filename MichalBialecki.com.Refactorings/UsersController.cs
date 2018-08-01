using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var conf = _configuration.GetSection("ConnectionStrings")["Blog"];
                using (var connection = new SqlConnection(conf))
                {
                    var user = await connection.QueryFirstOrDefaultAsync<UserDto>(
                        "SELECT [Id], [Name], [LastUpdatedAt] FROM [Users] WHERE Id = @Id",
                        new { Id = userId }).ConfigureAwait(false);

                    var userDesctiption = await GetUserDescription(userId);

                    return Json(user);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private async Task<string> GetUserDescription(int userId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"users/{userId}/description");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
