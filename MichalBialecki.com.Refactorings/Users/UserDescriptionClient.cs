using System.Net.Http;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Users
{
    public class UserDescriptionClient : IUserDescriptionClient
    {
        public async Task<string> GetUserDescription(int userId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"users/{userId}/description");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
