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
        private dynamic connection;

        public dbWool()
        {
            connection = new connectionWithDB().getConnection();
        }

        public Dictionary<dynamic, dynamic> getAllWools()
        {
            if (connection is String)
            {
                return connection;
            }

            var wools = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM wool", connection);
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

            return wools;
        }

        public Dictionary<dynamic, dynamic> getWool(long id)
        {
            if (connection is String)
            {
                return connection;
            }

            var wool = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM wool WHERE id =" + id, connection);
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

            return wool;
        }
    }
}
