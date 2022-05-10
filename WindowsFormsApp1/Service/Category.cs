using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
    //Категория животного собака
    //Категория животного кошка

    class dbCategory
    {
        private connectionWithDB connection;

        public dbCategory()
        {

        }

        public Dictionary<dynamic, dynamic> getAllCategories()
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var categories = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM category", getConnection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_category = reader.GetValue(0);
                    var name_category = reader.GetValue(1);
                    categories.Add(id_category, name_category);
                }
            }

            connection.closeConnection();
            return categories;
        }

        public Dictionary<dynamic, dynamic> getCategory(long id)
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var category = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM category WHERE id =" + id, getConnection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_category = reader.GetValue(0);
                    var name_category = reader.GetValue(1);
                    category.Add(id_category, name_category);
                }
            }

            connection.closeConnection();
            return category;
        }
    }
}
