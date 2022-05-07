using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
    class dbPhoto
    {
        private dynamic connection;

        public dbPhoto()
        {
            connection = new connectionWithDB().getConnection();
        }

        public Dictionary<dynamic, dynamic> getPhotosOfPet(long id)
        {
            if (connection is String)
            {
                return connection;
            }

            var photosOfPets = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM photo WHERE id_pet =" + id, connection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_photo = reader.GetValue(0);
                    var id_pet = reader.GetValue(1);
                    var filePath = reader.GetValue(2);
                    if (!photosOfPets.ContainsKey(id_photo))
                    {
                        photosOfPets.Add(id_photo, new Dictionary<dynamic, dynamic> { });
                    }
                    photosOfPets[id_photo].Add(id_pet, filePath);
                }
            }

            return photosOfPets;
        }
    }
}
