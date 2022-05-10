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
        private connectionWithDB connection;

        public dbSize()
        {

        }

        public Dictionary<dynamic, dynamic> getAllSizes()
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var sizes = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM size", getConnection);
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

            connection.closeConnection();
            return sizes;
        }

        public Dictionary<dynamic, dynamic> getSize(long id)
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var size = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM size WHERE id =" + id, getConnection);
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

            connection.closeConnection();
            return size;
        }
    }
}
