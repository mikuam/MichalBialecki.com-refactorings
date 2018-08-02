using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.DAL
{
    public interface IUsersRepository
    {
        Task<UserDto> Get(int userId);
    }
}