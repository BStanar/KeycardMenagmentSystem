using KeycardMenagmentSystem.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    public class UserService
    {
        private readonly string connectionString = "server=127.0.0.1;uid=root;database=keycardmenager;";

        public async Task AddUser(Users user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    var query = @"INSERT INTO `user` (`email`, `password`, `name`, `lastname`, `date_of_employment`, `role`) 
                                    VALUES (@email, @password, @name, @lastname, @startOfEmployment, @role);";
                    Console.WriteLine(query);
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@name", user.FirstName);
                        cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                        cmd.Parameters.AddWithValue("@startOfEmployment", user.StartOfEmployment);
                        cmd.Parameters.AddWithValue("@role", user.Role);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in AddUser: " + ex.Message);
                    throw;
                }
            }
        }

        public async Task<List<Users>> GetAllUsers()
        {
            List<Users> userList = new List<Users>();

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    var query = "SELECT * FROM `user`";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Users user = new Users
                                {
                                    ID = Convert.ToInt32(reader["id"]),
                                    Email = reader["email"].ToString(),
                                    Password = reader["password"].ToString(),
                                    FirstName = reader["name"].ToString(),
                                    Lastname = reader["lastname"].ToString(),
                                    StartOfEmployment = Convert.ToDateTime(reader["date_of_employment"]),
                                    Role = reader["role"].ToString()
                                };
                                userList.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in GetAllUsers: " + ex.Message);
                    throw;
                }
            }

            return userList;
        }
    }
}
