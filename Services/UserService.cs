using KeycardMenagmentSystem.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KeycardMenagmentSystem.Services
{
    public class UserService
    {
        private readonly string connectionString = "server=127.0.0.1;uid=root;database=keycardmanager;";

        public async Task AddUser(Users user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {       
                    await connection.OpenAsync();

                    
                     var query = @"INSERT INTO `user` ( `email`, `password`, `name`, `lastname`, `date_of_employment`, `role`) VALUES(@email, @password, @name, @lastname,  '24-02-2024', 'Employee');";
                    Console.WriteLine(query);
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@name", user.FirstName);
                        cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                      //  cmd.Parameters.AddWithValue("@date_Of_employment", "2024-02-01");
                      //  cmd.Parameters.AddWithValue("@role", "manager");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception, log or throw as needed
                    Console.WriteLine("Exception in AddUser: " + ex.Message);
                    throw;
                }
            }
        }

    }
}
