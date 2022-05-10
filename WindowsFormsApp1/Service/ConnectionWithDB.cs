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

        private NpgsqlConnection connection;

        public dynamic getConnection()
        {
            //var connectionDataToDestroyIdleConections = "Host=" + host + ";Username=" + username + ";Password=" + password + ";Database=postgres;Port=" + port;
            //var connectionToDestroyIdleConections = new NpgsqlConnection(connectionDataToDestroyIdleConections);
            //try
            //{
            //    connectionToDestroyIdleConections.Open();
            //    if (connectionToDestroyIdleConections.FullState == System.Data.ConnectionState.Broken || connectionToDestroyIdleConections.FullState == System.Data.ConnectionState.Closed)
            //    {
            //        Console.WriteLine("Соединение не было установлено");
            //        return "Соединение не было установлено";
            //    }
            //    NpgsqlCommand command = new NpgsqlCommand("SELECT pid, usename, usesysid, datid, datname, application_name, backend_start,state_change, state FROM pg_stat_activity WHERE datname=ISPets, state=idle", connectionToDestroyIdleConections);
            //    NpgsqlDataReader reader = command.ExecuteReader();
            //    List<int> badConnections = new List<int>();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            var pid = reader.GetInt32(0);
            //            badConnections.Add(pid);
            //        }
            //    }

            //    foreach(var pid in badConnections)
            //    {
            //        command = new NpgsqlCommand("SELECT pg_terminate_backend(" + pid + ")");
            //        reader = command.ExecuteReader();
            //        reader.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return ex.ToString();
            //}

            var connectionData = "Host=" + host + ";Username=" + username + ";Password=" + password + ";Database=" + database + ";Port=" + port;
            connection = new NpgsqlConnection(connectionData);
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

        public void closeConnection()
        {
            connection.Close();
        }
    }
}
