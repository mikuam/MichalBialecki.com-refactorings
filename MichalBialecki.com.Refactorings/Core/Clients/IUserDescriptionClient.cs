using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Core.Clients
{
    public interface IUserDescriptionClient
    {
        Task<string> GetUserDescription(int userId);
    }
}
