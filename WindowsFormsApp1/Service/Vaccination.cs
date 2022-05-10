using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
    //Против бешенства собака, кошка
    //Против чумы собака
    //Против парвовирусного энтерита собака
    //Против аденовироза собака
    //Против парагриппа собака
    //Против лептоспироза кошка
    //Против панлейкопении кошка
    //Против калицивироза кошка
    //Против герпесвирусной инфекции кошка
    //Против хламидиоза кошка
    class dbVaccination
    {
        private connectionWithDB connection;

        public dbVaccination()
        {

        }

        public Dictionary<dynamic, dynamic> getVaccinationsOfPet(long id)
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var vaccinationsOfPet = new Dictionary<dynamic, dynamic> { };
            var standardVaccinations = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand commandVaccinations = new NpgsqlCommand("SELECT * FROM vaccination", getConnection);

            var secondConnection = new connectionWithDB();
            var secondGetConnection = secondConnection.getConnection();
            if (secondGetConnection is String)
            {
                return secondGetConnection;
            }
            NpgsqlCommand commandVaccinationsOfPet = new NpgsqlCommand("SELECT * FROM pet_vaccination WHERE id_pet =" + id, secondGetConnection);

            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader readerVaccinations = commandVaccinations.ExecuteReader();
            if (readerVaccinations.HasRows)
            {
                while (readerVaccinations.Read())
                {
                    var id_vaccination = readerVaccinations.GetValue(0);
                    var name_vaccination = readerVaccinations.GetValue(1);
                    standardVaccinations.Add(id_vaccination, name_vaccination);
                }
            }

            NpgsqlDataReader readerVaccinationsOfPet = commandVaccinationsOfPet.ExecuteReader();
            if (readerVaccinationsOfPet.HasRows)
            {
                while (readerVaccinationsOfPet.Read())
                {
                    var id_pet = readerVaccinationsOfPet.GetValue(1);
                    var id_vaccination = readerVaccinationsOfPet.GetValue(2);
                    var name_vaccination = standardVaccinations[id_vaccination];
                    var date_vaccination = readerVaccinationsOfPet.GetValue(0);
                    var index = id_pet+"_"+id_vaccination;

                    vaccinationsOfPet.Add(index, new Dictionary<dynamic, dynamic> ());

                    vaccinationsOfPet[index].Add("id_pet", id_pet);
                    vaccinationsOfPet[index].Add("id_vaccination", id_vaccination);
                    vaccinationsOfPet[index].Add("name_vaccination", name_vaccination);
                    vaccinationsOfPet[index].Add("date_vaccination", date_vaccination);
                }
            }

            connection.closeConnection();
            secondConnection.closeConnection();
            return vaccinationsOfPet;
        }
    }
}
