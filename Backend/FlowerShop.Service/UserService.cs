using FlowerShop.Models;
using FlowerShop.Repository;
using FlowerShop.Repository.Common;
using FlowerShop.Service.Common;

namespace FlowerShop.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }



        public async Task<List<string>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task PostUser(User user)
        {
            await userRepository.PostUser(user);
        }

        public async Task UpdateUserByRole(string oldRole, string newRole, User user)
        {
            await userRepository.UpdateUserByRole(oldRole, newRole, user);
        }

        public async Task DeleteUser(int id)
        {
            await userRepository.DeleteUser(id);
        }
    }
}
