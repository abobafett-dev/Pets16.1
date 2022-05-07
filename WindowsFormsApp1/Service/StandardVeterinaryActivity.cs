using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WindowsFormsApp1.Service
{
    //Обработка от эктопаразитов
    //Дегельминтизация
    class dbStandardVeterinaryActivity
    {
        private dynamic connection;

        public dbStandardVeterinaryActivity()
        {
            connection = new connectionWithDB().getConnection();
        }

        public Dictionary<dynamic, dynamic> getAllStandardVeterinaryActivties()
        {
            if (connection is String)
            {
                return connection;
            }

            var standardVeterinaryActivities = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM standardveterinaryactivity", connection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_standardVeterinaryActivity = reader.GetValue(0);
                    var description_standardVeterinaryActivity = reader.GetValue(1);
                    standardVeterinaryActivities.Add(id_standardVeterinaryActivity, description_standardVeterinaryActivity);
                }
            }

            return standardVeterinaryActivities;
        }

        public Dictionary<dynamic, dynamic> getStandardVeterinaryActivity(long id)
        {
            if (connection is String)
            {
                return connection;
            }

            var standardVeterinaryActivity = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM standardVeterinaryActivity WHERE id =" + id, connection);
            //int rows_changed = command.ExecuteNonQuery();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id_standardVeterinaryActivity = reader.GetValue(0);
                    var description_standardVeterinaryActivity = reader.GetValue(1);
                    standardVeterinaryActivity.Add(id_standardVeterinaryActivity, description_standardVeterinaryActivity);
                }
            }

            return standardVeterinaryActivity;
        }
    }
}
