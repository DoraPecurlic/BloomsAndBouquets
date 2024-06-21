using Microsoft.AspNetCore.Mvc;
using FlowerShop.Service;
using FlowerShop.Models;
using FlowerShop.Service.Common;

namespace FlowerShop.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrderController : ControllerBase
    {
       // private string connectionString = WebApplication.Create().Configuration.GetConnectionString("DefaultConnection");

        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }





        [HttpGet(Name = "GetUserOrders")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            List<String> orders = new List<String>();
            try
            {
                orders = await orderService.GetUserOrders(userId);


                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }

        [HttpPost(Name = "PostOrder")]

        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            try
            {

                await orderService.PostOrder(order);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        


        [HttpDelete(Name = "DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            
            try
            {

                await orderService.DeleteOrder(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


















    }
}
