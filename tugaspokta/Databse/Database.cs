using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace tugaspokta.Databse
{
    public class Database
    {
        string mysqlconnectionstring = "Server=localhost;Database=siakada ;Uid=root;Pwd=;";
        public MySqlConnection mysqlconnection()
        {
            return new MySqlConnection(mysqlconnectionstring);

        }
            
    }
}
