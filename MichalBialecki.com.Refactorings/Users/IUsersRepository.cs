using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Users
{
    public interface IUsersRepository
    {
        Task<UserDto> Get(int userId);
    }
}