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
        private dynamic connection;

        public dbCategory()
        {
            connection = new connectionWithDB().getConnection();
        }

        public Dictionary<dynamic, dynamic> getAllCategories()
        {
            if (connection is String)
            {
                return connection;
            }

            var categories = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM category", connection);
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

            return categories;
        }

        public Dictionary<dynamic, dynamic> getCategory(long id)
        {
            if (connection is String)
            {
                return connection;
            }

            var category = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM category WHERE id =" + id, connection);
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

            return category;
        }
    }
}
