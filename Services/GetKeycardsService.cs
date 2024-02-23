using KeycardMenagmentSystem.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    public class GetKeycardsService:IGetKeycardsService
    {
        private string connectionString = "server=127.0.0.1;uid=root;database=keycardmenager;";

        public async Task<List<Keycard>> GetAccessLogsService()
        {
            var logs = new List<Keycard>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT 
    k.id AS KeycardID, 
    k.serial_number AS KeycardSerial, 
    k.user_id AS UserID, 
    u.name AS UserName, 
    u.lastname AS UserLastName,
    k.activated AS Activated
FROM 
    keycard k
LEFT JOIN 
    user u ON k.user_id = u.id
ORDER BY 
    k.id ASC;";


                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var keycardID = Convert.ToInt32(reader["KeycardID"]);
                            var serialCode = reader["KeycardSerial"].ToString();

                            // Handling potential DBNull for UserID
                            int userId = reader["UserID"] is DBNull ? 0 : Convert.ToInt32(reader["UserID"]);

                            // Handling potential DBNull for UserName and UserLastName
                            string userName = reader["UserName"] is DBNull ? "" : reader["UserName"].ToString();
                            string userLastName = reader["UserLastName"] is DBNull ? "" : reader["UserLastName"].ToString();

                            bool activated = Convert.ToBoolean(reader["Activated"]);

                            var log = new Keycard(keycardID, serialCode, userId, activated, userName, userLastName );
                            logs.Add(log);
                        }
                        }

                    
                }
            }

            return logs;
        }
    }
}
