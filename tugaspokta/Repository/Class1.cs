using System;
using MySql.Data.MySqlClient;
using tugaspokta.Databse;
using tugaspokta.Model;

namespace tugaspokta.Repository
{
    public class UserRepository
    {
        public bool ValidateLogin(string username, string email, string password)
        {
            Database db = new Database();
            using (MySqlConnection connection = db.mysqlconnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT full_name, role FROM users WHERE username = @username AND email = @email AND password_hash = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error DB: " + ex.Message);
                }
            }
            return false;
        }
    }
}