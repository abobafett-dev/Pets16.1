using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace WindowsFormsApp1.Service
{
    class dbPet
    {
        private connectionWithDB connection;

        public dbPet()
        {

        }

        public Dictionary<dynamic, dynamic> getPet(long id)
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var pet = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pet WHERE id =" + id, getConnection);

            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_pet = reader.GetValue(0);
                    var id_category = reader.GetValue(1);
                    var id_size = reader.GetValue(2);
                    var id_wool = reader.GetValue(3);
                    var name = reader.GetValue(4);
                    var dateRegistry = reader.GetValue(5);
                    var birthday = reader.GetValue(6);
                    var passportNumber = reader.GetValue(7);
                    var ownerName = reader.GetValue(8);
                    var breed = reader.GetValue(9);
                    var id_gender = reader.GetValue(10);
                    pet.Add("id_pet", id_pet);
                    pet.Add("id_category", id_category);
                    pet.Add("id_gender", id_gender);
                    pet.Add("id_size", id_size);
                    pet.Add("id_wool", id_wool);
                    pet.Add("name", name);
                    pet.Add("dateRegistry", dateRegistry);
                    pet.Add("birthday", birthday);
                    pet.Add("passportNumber", passportNumber);
                    pet.Add("ownerName", ownerName);
                    pet.Add("breed", breed);

                }
            }

            connection.closeConnection();
            return pet;
        }

        public Dictionary<dynamic, dynamic> getPets()
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var pets = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM pet", getConnection);

            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_pet = reader.GetValue(0);
                    var id_category = reader.GetValue(1);
                    var id_size = reader.GetValue(2);
                    var id_wool = reader.GetValue(3);
                    var name = reader.GetValue(4);
                    var dateRegistry = reader.GetValue(5);
                    var birthday = reader.GetValue(6);
                    var passportNumber = reader.GetValue(7);
                    var ownerName = reader.GetValue(8);
                    var breed = reader.GetValue(9);
                    var id_gender = reader.GetValue(10);
                    if (!pets.ContainsKey(id_pet))
                    {
                        pets.Add(id_pet, new Dictionary<dynamic, dynamic> { });
                    }
                    pets[id_pet].Add("id_pet", id_pet);
                    pets[id_pet].Add("id_category", id_category);
                    pets[id_pet].Add("id_gender", id_gender);
                    pets[id_pet].Add("id_size", id_size);
                    pets[id_pet].Add("id_wool", id_wool);
                    pets[id_pet].Add("name", name);
                    pets[id_pet].Add("dateRegistry", dateRegistry);
                    pets[id_pet].Add("birthday", birthday);
                    pets[id_pet].Add("passportNumber", passportNumber);
                    pets[id_pet].Add("ownerName", ownerName);
                    pets[id_pet].Add("breed", breed);

                }
            }

            connection.closeConnection();
            return pets;
        }
    }
}
