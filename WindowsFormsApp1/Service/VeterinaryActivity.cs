using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Service
{
    class dbVeterinaryActivity
    {

        private dynamic connection;

        public dbVeterinaryActivity()
        {
            connection = new connectionWithDB().getConnection();
        }

        public Dictionary<dynamic, dynamic> getDocumentsOfPet(long id)
        {
            connection = new connectionWithDB().getConnection();
            if (connection is String)
            {
                return connection;
            }

            var documentsOfPet = new Dictionary<dynamic, dynamic> { };

            var dbStandardVeterinaryActivity = new dbStandardVeterinaryActivity();
            var standardVeterinaryActivities = dbStandardVeterinaryActivity.getAllStandardVeterinaryActivties();

            NpgsqlCommand commanddocumentsOfPet = new NpgsqlCommand("SELECT * FROM veterinaryactivity WHERE id_pet =" + id, connection);

            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = commanddocumentsOfPet.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_veterinaryActivity = reader.GetValue(0);
                    var id_pet = reader.GetValue(1);
                    var description_veterinaryActivity = reader.GetValue(2);
                    var date_veterinaryActivity = reader.GetValue(3);
                    var filePath_veterinaryActivity = reader.GetValue(4);
                    var wasPassed_veterinaryActivity = reader.GetValue(5);
                    var id_standardVeterinaryActivity = reader.GetValue(6);
                    if (!documentsOfPet.ContainsKey(id_veterinaryActivity))
                    {
                        documentsOfPet.Add(id_veterinaryActivity, new Dictionary<dynamic, dynamic> { });
                    }
                    documentsOfPet[id_veterinaryActivity].Add("description_veterinaryActivity", description_veterinaryActivity);
                    documentsOfPet[id_veterinaryActivity].Add("id_pet", id_pet);
                    documentsOfPet[id_veterinaryActivity].Add("date_veterinaryActivity", date_veterinaryActivity);
                    documentsOfPet[id_veterinaryActivity].Add("filePath_veterinaryActivity", filePath_veterinaryActivity);
                    documentsOfPet[id_veterinaryActivity].Add("wasPassed_veterinaryActivity", wasPassed_veterinaryActivity);
                    documentsOfPet[id_veterinaryActivity].Add("id_standardVeterinaryActivity", id_standardVeterinaryActivity);
                    documentsOfPet[id_veterinaryActivity].Add("name_standardVeterinaryActivity", standardVeterinaryActivities[id_standardVeterinaryActivity]);
                }
            }

            return documentsOfPet;
        }

        public Dictionary<dynamic, dynamic> getVeterinaryActivitiesOfPet(long id)
        {
            if (connection is String)
            {
                return connection;
            }

            var documentsOfPet = new Dictionary<dynamic, dynamic> { };

            var dbStandardVeterinaryActivity = new dbStandardVeterinaryActivity();
            var standardVeterinaryActivities = dbStandardVeterinaryActivity.getAllStandardVeterinaryActivties();

            NpgsqlCommand commanddocumentsOfPet = new NpgsqlCommand("SELECT * FROM veterinaryactivity WHERE id_pet =" + id, connection);

            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = commanddocumentsOfPet.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_veterinaryActivity = reader.GetValue(0);
                    var id_pet = reader.GetValue(1);
                    var description_veterinaryActivity = reader.GetValue(2);
                    var date_veterinaryActivity = reader.GetValue(3);
                    var filePath_veterinaryActivity = reader.GetValue(4);
                    var wasPassed_veterinaryActivity = reader.GetValue(5);
                    var id_standardVeterinaryActivity = reader.GetValue(6);
                    if (!documentsOfPet.ContainsKey(wasPassed_veterinaryActivity))
                    {
                        documentsOfPet.Add(wasPassed_veterinaryActivity, new Dictionary<dynamic, dynamic> { });
                    }
                    documentsOfPet[wasPassed_veterinaryActivity].Add(id_veterinaryActivity, new Dictionary<dynamic, dynamic> { });
                    documentsOfPet[wasPassed_veterinaryActivity][id_veterinaryActivity].Add("id_veterinaryActivity", id_veterinaryActivity);
                    documentsOfPet[wasPassed_veterinaryActivity][id_veterinaryActivity].Add("id_pet", id_pet);
                    documentsOfPet[wasPassed_veterinaryActivity][id_veterinaryActivity].Add("description_veterinaryActivity", description_veterinaryActivity);
                    documentsOfPet[wasPassed_veterinaryActivity][id_veterinaryActivity].Add("date_veterinaryActivity", date_veterinaryActivity);
                    documentsOfPet[wasPassed_veterinaryActivity][id_veterinaryActivity].Add("filePath_veterinaryActivity", filePath_veterinaryActivity);
                    documentsOfPet[wasPassed_veterinaryActivity][id_veterinaryActivity].Add("id_standardVeterinaryActivity", id_standardVeterinaryActivity);
                    documentsOfPet[wasPassed_veterinaryActivity][id_veterinaryActivity].Add("name_standardVeterinaryActivity", standardVeterinaryActivities[id_standardVeterinaryActivity]);
                }
            }

            return documentsOfPet;
        }
    }
}
