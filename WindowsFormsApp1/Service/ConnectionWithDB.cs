using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
    class connectionWithDB
    {
        private string host = "25.51.240.40";
        private string username = "postgres";
        private string password = "postgres";
        private string database = "ISPets";
        private string port = "5434";

        public dynamic getConnection()
        {
            var connectionData = "Host=" + host + ";Username=" + username + ";Password=" + password + ";Database=" + database + ";Port=" + port;
            var connection = new NpgsqlConnection(connectionData);
            try
            {
                connection.Open();
                if (connection.FullState == System.Data.ConnectionState.Broken || connection.FullState == System.Data.ConnectionState.Closed)
                {
                    Console.WriteLine("Соединение не было установлено");
                    return "Соединение не было установлено";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return connection;
        }
    }
}
