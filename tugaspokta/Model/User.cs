using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using tugaspokta.Databse;

namespace tugaspokta.Model
{
    public class User
    {
        public string username {  get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string full_name { get; set; }
        public string role { get; set; }

        public bool ValidateLogin(string username, string email, string password_hash)
        {
            Database db = new Database();
            using (MySqlConnection connection = db.mysqlconnection())
            {
                try
                {
                    connection.Open();
                    string query = "select full_name, role from users where username = @username and email = @email and password_hash = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password_hash);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                this.username = username;
                                this.email = email;
                                this.full_name = reader["full_name"].ToString();
                                this.role = reader["role"].ToString();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }


                return false;
            }

        }
    }
}
