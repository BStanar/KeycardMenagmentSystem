using KeycardManagementSystem.Model;
using KeycardMenagmentSystem.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Services
{
    internal class GetLogsService:IGetAccessLogs
    {
        private string connectionString = "server=127.0.0.1;uid=root;database=keycardmenager;";

        

        public async Task<List<AccessLog>> GetAccesLogs()
        {
            var logs = new List<AccessLog>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT 
                    l.id AS LogID, 
                    l.accesspoint_id, 
                    a.name AS AccessPointName, 
                    l.keycard_id, 
                    k.serial_number AS KeycardSerial, 
                    l.user_id, 
                    l.eventdate, 
                    l.successful, 
                    l.number_of_scans, 
                    u.name AS firstname, 
                    u.lastname
                    FROM log l
                    JOIN user u ON l.user_id = u.id
                    JOIN accesspoint a ON l.accesspoint_id = a.id
                    JOIN keycard k ON l.keycard_id = k.id
                    ORDER BY l.eventdate DESC;
                    ";


                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var log = new AccessLog(
                                Convert.ToInt32(reader["LogID"]),
                                Convert.ToInt32(reader["accesspoint_id"]),
                                reader["AccessPointName"].ToString(),
                                Convert.ToInt32(reader["keycard_id"]),
                                reader["KeycardSerial"].ToString(),
                                Convert.ToInt32(reader["user_id"]),
                                Convert.ToDateTime(reader["eventdate"]),
                                Convert.ToBoolean(reader["successful"]),
                                Convert.ToInt32(reader["number_of_scans"]),
                                reader["firstname"].ToString(),
                                reader["lastname"].ToString()
                            );
                            logs.Add(log);

                        }
                    }
                }
            }

            return logs;
        }
    }
}
