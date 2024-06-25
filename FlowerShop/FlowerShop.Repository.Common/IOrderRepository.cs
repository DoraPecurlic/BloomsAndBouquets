using FlowerShop.Models;

namespace FlowerShop.Repository.Common
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetUserOrders(int userId);
        Task PostOrder(Order order);
        Task DeleteOrder(int id);

    }
}
