using FlowerShop.Models;

using FlowerShop.Repository.Common;
using FlowerShop.Service.Common;

namespace FlowerShop.Service
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }


        public async Task<List<string>> GetUserOrders(int userId)
        {
            return await orderRepository.GetUserOrders(userId);
        }

        public async Task PostOrder(Order order)
        {
             await orderRepository.PostOrder(order);
        }
        public async Task DeleteOrder(int id)
        {
            await orderRepository.DeleteOrder(id);
        }
    }
}
