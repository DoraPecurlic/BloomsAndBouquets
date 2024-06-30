using FlowerShop.Models;
using FlowerShop.Repository.Common;
using Npgsql;

namespace FlowerShop.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public async Task<List<String>> GetUsers()
        {
            List<String> users = new List<String>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM ""User"" ";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var userId = reader.GetInt32(0);
                            var firstName = reader.GetString(1);
                            var lastName = reader.GetString(2);
                            var role = reader.GetString(3);

                            var userInfo = $"UserID: {userId}, First Name: {firstName}, Last Name: {lastName}, Role: {role}";

                            users.Add(userInfo);
                           
                        }
                    }
                }
            }
            return users;

        }

        public async Task PostUser(User user)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO ""User"" (""FirstName"", ""LastName"", ""Role"") 
                                        VALUES (@FirstName, @LastName, @Role)";

                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Role", user.Role);

                    await command.ExecuteNonQueryAsync();


                }
            }
        }

        public async Task UpdateUserByRole(string oldRole, string newRole, User user)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = @"UPDATE ""User"" 
                                        SET ""FirstName"" = @FirstName, ""LastName"" = @LastName, ""Role"" = @NewRole
                                        WHERE ""Role"" = @OldRole";

                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@NewRole", newRole);
                    command.Parameters.AddWithValue("@OldRole", oldRole);

                    

                    int rowsAffected = await command.ExecuteNonQueryAsync(); 

                    if (rowsAffected == 0)
                    {
                        throw new Exception($"No users with Role = {oldRole} found.");
                        
                    }
                }
            }
        }



        public async Task DeleteUser(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM ""User"" WHERE ""Id"" = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new Exception($"User with Id = {id} not found.");
                       
                    }

                }
            }
        }
    }
}
