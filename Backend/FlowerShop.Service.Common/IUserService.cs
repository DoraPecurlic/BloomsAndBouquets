using FlowerShop.Models;

namespace FlowerShop.Service.Common
{
    public interface IUserService
    {
        Task<List<string>> GetUsers();
        Task PostUser(User user);

        Task UpdateUserByRole(string oldRole, string newRole, User user);

        Task DeleteUser(int id);
    }
}
