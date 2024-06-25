using FlowerShop.Models;
using FlowerShop.Repository.Common;
using Npgsql;
namespace FlowerShop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private  string connectionString;
        Order order = new Order();
        OrderType orderType = new OrderType();
        public OrderRepository(string connectionString) {
            this.connectionString = connectionString;
        }

       

        public async Task<List<Order>> GetUserOrders(int userId)
        {
            List<Order> userOrders = new List<Order>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = @"SELECT * FROM ""Order""  WHERE ""UserId"" = @UserId ";

                     command.Parameters.AddWithValue("@UserId", userId);


                    using (var reader = await command.ExecuteReaderAsync() ) 
                    {
                        while (await reader.ReadAsync())
                        {
                            var order = new Order
                            {
                                Id = reader.GetInt32(0),
                                FlowerType = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                OrderTypeId = reader.GetInt32(3)
                            };

                            userOrders.Add(order);
                        }
                    }
                    

                }
            }

            return userOrders;
        }

        public async Task PostOrder(Order order)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                            INSERT INTO ""Order"" (""FlowerType"", ""Quantity"", ""OrderTypeId"", ""UserId"" )
                            VALUES (@FlowerType, @Quantity, @OrderTypeId, @UserId)";


                    command.Parameters.AddWithValue("FlowerType", order.FlowerType);
                    command.Parameters.AddWithValue("Quantity", order.Quantity);
                    command.Parameters.AddWithValue("OrderTypeId", order.OrderTypeId);
                    command.Parameters.AddWithValue("UserId", order.UserId);

                    await command.ExecuteNonQueryAsync();




                }

            }


                
        }

        public async Task DeleteOrder(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM ""Order"" WHERE ""Id"" = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync(); 

                    if (rowsAffected == 0)
                    {
                        throw new Exception($"No order with Id = {id} found.");
                    }
                }
            }
        }


    }
}
