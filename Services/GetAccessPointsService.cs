using KeycardMenagmentSystem.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    internal class GetAccessPointsService : IGetAccessPointService
    {
        private string connectionString = "server=127.0.0.1;uid=root;database=keycardmenager;";

        public async Task<List<AccessPoint>> GetAccesPoints()
        {
            var accessPoints = new List<AccessPoint>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                // Update your query to also select the 'serial' column
                var query = "SELECT id, name, serial FROM accesspoint;";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Update the AccessPoint object creation to include the new 'serial' field
                            var accessPoint = new AccessPoint(
                                Convert.ToInt32(reader["id"]),
                                reader["name"].ToString(),
                                reader["serial"].ToString() 
                                // Make sure to read the 'serial' column from the database
                            );
                            accessPoints.Add(accessPoint);
                        }
                    }
                }
            }

            return accessPoints;
        }

        public async Task AddAccessPoint(AccessPoint accessPoint)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO accesspoint (name, serial) VALUES (@name, @serial);";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Assuming AccessPoint class has Name and Serial properties
                    cmd.Parameters.AddWithValue("@name", accessPoint.Name);
                    cmd.Parameters.AddWithValue("@serial", accessPoint.Serial);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
