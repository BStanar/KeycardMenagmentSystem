using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using KeycardMenagmentSystem.Model;
using MySqlConnector;
using KeycardManagmentSystem.Services;

namespace KeycardMenagmentSystem.Services
{
    public class AddKeycardService : IAddNewKeycard
    {
        private string connectionString = "server=127.0.0.1;uid=root;pwd=yourpassword;database=keycardmanager;";

        public async Task AddNewKeycard(Keycard keycard)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO keycards (serial_number, user_id, activated) VALUES (@serialNumber, @userId, @activated);";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@serialNumber", keycard.SerialCode);
                    cmd.Parameters.AddWithValue("@userId", keycard.UserId == 0 ? DBNull.Value : (object)keycard.UserId);
                    cmd.Parameters.AddWithValue("@activated", keycard.Activated);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
