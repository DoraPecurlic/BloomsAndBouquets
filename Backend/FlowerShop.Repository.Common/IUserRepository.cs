using FlowerShop.Models;


namespace FlowerShop.Repository.Common
{
    public interface IUserRepository
    {
        Task<List<string>> GetUsers();
        Task PostUser(User user);
        Task UpdateUserByRole(string oldRole, string newRole, User user);
        Task DeleteUser(int id);
    }
}
