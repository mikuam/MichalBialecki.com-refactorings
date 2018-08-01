using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Users
{
    public class UsersRepository : IUsersRepository
    {
        private static class SqlQueries {
            internal static string GetUser = "SELECT [Id], [Name], [LastUpdatedAt] FROM [Users] WHERE Id = @Id";
        }

        private readonly IConfiguration _configuration;

        public UsersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserDto> Get(int userId)
        {
            var conf = _configuration.GetSection("ConnectionStrings")["Blog"];
            using (var connection = new SqlConnection(conf))
            {
                var user = await connection.QueryFirstOrDefaultAsync<UserDto>(
                    SqlQueries.GetUser,
                    new { Id = userId }).ConfigureAwait(false);

                return user;
            }
        }
    }
}
