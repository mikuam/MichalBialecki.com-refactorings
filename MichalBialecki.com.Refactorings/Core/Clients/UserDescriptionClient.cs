using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Core.Clients
{
    public class UserDescriptionClient : BaseClient<string>, IUserDescriptionClient
    {
        public async Task<string> GetUserDescription(int userId)
        {
            return await Get($"users/{userId}/description");
        }
    }
}
