using FlowerShop.Models;

namespace FlowerShop.Service.Common
{
    public interface IOrderService
    {
        Task<List<string>> GetUserOrders(int userId);
        Task PostOrder(Order order);
        Task DeleteOrder(int id);
        

    }


}