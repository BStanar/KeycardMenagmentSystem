﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    class AuthenticationService:IAuthenticationService
    {
        private string connectionString = "server=127.0.0.1;uid=root;database=keycardmenager;";

        public async Task Login(string username, string password)
        {
            await Task.Yield();

            bool isAuthenticated = false;

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    var query = @"
                    SELECT u.*
                    FROM `user` u
                    LEFT JOIN `keycard` k ON u.`id` = k.`user_id`
                    WHERE (u.`username` = @identifier OR u.`email` = @identifier OR k.`serial_number` = @identifier)
                      AND u.`password` = @password
                    LIMIT 1;
                ";

                    using (var cmd = new MySqlCommand(query, connection))
                    {

                        // Safely add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@identifier", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            // If any rows are returned, the user is authenticated
                            isAuthenticated = reader.HasRows;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Consider logging the exception
                    throw new Exception("string"+password, ex);
                }
            }

            if (!isAuthenticated)
            {
                throw new UnauthorizedAccessException("Login failed. Please check your credentials.");
            }
        }
    }
}
