using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
    //Шерсть короткошерстная
    //Шерсть длинношерстная
    //Шерсть жесткошерстная
    //Шерсть кудрявая
    class dbWool
    {
        private connectionWithDB connection;

        public dbWool()
        {

        }

        public Dictionary<dynamic, dynamic> getAllWools()
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var wools = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM wool", getConnection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_wool = reader.GetValue(0);
                    var name_wool = reader.GetValue(1);
                    wools.Add(id_wool, name_wool);
                }
            }

            connection.closeConnection();
            return wools;
        }

        public Dictionary<dynamic, dynamic> getWool(long id)
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var wool = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM wool WHERE id =" + id, getConnection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_wool = reader.GetValue(0);
                    var name_wool = reader.GetValue(1);
                    wool.Add(id_wool, name_wool);
                }
            }

            connection.closeConnection();
            return wool;
        }
    }
}
