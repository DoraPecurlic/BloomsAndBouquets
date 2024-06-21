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

       

        public async Task<List<String>> GetUserOrders(int userId)
        {
            List<string> userOrders = new List<string>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = @"SELECT   o.""Id"",  o.""FlowerType"", o.""Quantity"", ot.""OrderType"" " +
                        @"FROM ""Order"" o   " +
                        @"INNER JOIN    ""OrderType"" ot ON o.""OrderTypeId"" = ot.""Id""  WHERE  o.""UserId"" = @UserId ";

                    command.Parameters.AddWithValue("@UserId", userId);


                    using (var reader = await command.ExecuteReaderAsync() ) 
                    {
                        while (await reader.ReadAsync())
                        {
                            var orderId = reader.GetInt32(0);
                            var flowerType = reader.GetString(1);
                            var quantity = reader.GetInt32(2);
                            var orderType = reader.GetString(3);

                            var orderInfo = $"Your order id: {orderId}, Flower: {flowerType}, Quantity: {quantity}, Order type: {orderType}";
                            userOrders.Add(orderInfo);
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
