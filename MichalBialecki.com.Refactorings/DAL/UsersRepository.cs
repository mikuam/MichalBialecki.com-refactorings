using Dapper;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.DAL
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        private static class SqlQueries {
            internal static string GetUser = "SELECT [Id], [Name], [LastUpdatedAt] FROM [Users] WHERE Id = @Id";
        }
        
        public UsersRepository(IConfiguration configuration) : base(configuration) {}

        public async Task<UserDto> Get(int userId)
        {
            using (var connection = GetBlogConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<UserDto>(
                    SqlQueries.GetUser,
                    new { Id = userId }).ConfigureAwait(false);

                return user;
            }
        }
    }
}
