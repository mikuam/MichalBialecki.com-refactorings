using System.Threading.Tasks;
using MichalBialecki.com.Refactorings.Dtos;

namespace MichalBialecki.com.Refactorings.Core.Services
{
    public interface IUserService
    {
        Task<User> GetUser(int userId);
    }
}