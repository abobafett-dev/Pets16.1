using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
    //Пол животного кобель
    //Пол животного сука
    //Пол животного кот
    //Пол животного кошка
    class dbGender
    {
        private dynamic connection;

        public dbGender()
        {
            connection = new connectionWithDB().getConnection();
        }

        public Dictionary<dynamic, dynamic> getAllGenders()
        {
            if (connection is String)
            {
                return connection;
            }

            var genders = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM gender", connection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_gender = reader.GetValue(0);
                    var id_category = reader.GetValue(2);
                    var name_gender = reader.GetValue(1);
                    if(!genders.ContainsKey(id_category))
                    {
                        genders.Add(id_category, new Dictionary<dynamic, dynamic> { });
                    }
                    genders[id_category].Add(id_gender, name_gender);
                }
            }

            return genders;
        }

        public Dictionary<dynamic, dynamic> getGender(long id)
        {
            if (connection is String)
            {
                return connection;
            }

            var gender = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM gender WHERE id =" + id, connection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_gender = reader.GetValue(0);
                    var id_category = reader.GetValue(2);
                    var name_gender = reader.GetValue(1);
                    if (!gender.ContainsKey(id_category))
                    {
                        gender.Add(id_category, new Dictionary<dynamic, dynamic> { });
                    }
                    gender[id_category].Add(id_gender, name_gender);
                }
            }

            return gender;
        }
    }
}
