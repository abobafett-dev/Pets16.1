using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
//Размер животного маленькое
//Размер животного среднее
//Размер животного большое
    class dbSize
    {
        private dynamic connection;

        public dbSize()
        {
            connection = new connectionWithDB().getConnection();
        }

        public Dictionary<dynamic, dynamic> getAllSizes()
        {
            if (connection is String)
            {
                return connection;
            }

            var sizes = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM size", connection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_size = reader.GetValue(0);
                    var name_size = reader.GetValue(1);
                    sizes.Add(id_size, name_size);
                }
            }

            return sizes;
        }

        public Dictionary<dynamic, dynamic> getSize(long id)
        {
            if (connection is String)
            {
                return connection;
            }

            var size = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM size WHERE id =" + id, connection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_size = reader.GetValue(0);
                    var name_size = reader.GetValue(1);
                    size.Add(id_size, name_size);
                }
            }

            return size;
        }
    }
}
