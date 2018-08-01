using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Users
{
    public interface IUserDescriptionClient
    {
        Task<string> GetUserDescription(int userId);
    }
}
