using MichalBialecki.com.Refactorings.Core.Clients;
using MichalBialecki.com.Refactorings.DAL;
using MichalBialecki.com.Refactorings.Dtos;
using System.Threading.Tasks;

namespace MichalBialecki.com.Refactorings.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserDescriptionClient _userDescriptionClient;

        public UserService(IUsersRepository usersRepository, IUserDescriptionClient userDescriptionClient)
        {
            _usersRepository = usersRepository;
            _userDescriptionClient = userDescriptionClient;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _usersRepository.Get(userId);
            var userDesctiption = await _userDescriptionClient.GetUserDescription(userId);

            return new User
            {
                Id = user.Id,
                Name = user.Name,
                LastModified = user.LastModified,
                Description = userDesctiption
            };
        }
    }
}
