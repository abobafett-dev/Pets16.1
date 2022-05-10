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
        private connectionWithDB connection;

        public dbStandardVeterinaryActivity()
        {

        }

        public Dictionary<dynamic, dynamic> getAllStandardVeterinaryActivties()
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var standardVeterinaryActivities = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM standardveterinaryactivity", getConnection);
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

            connection.closeConnection();
            return standardVeterinaryActivities;
        }

        public Dictionary<dynamic, dynamic> getStandardVeterinaryActivity(long id)
        {
            connection = new connectionWithDB();
            var getConnection = connection.getConnection();
            if (getConnection is String)
            {
                return getConnection;
            }

            var standardVeterinaryActivity = new Dictionary<dynamic, dynamic> { };

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM standardVeterinaryActivity WHERE id =" + id, getConnection);
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

            connection.closeConnection();
            return standardVeterinaryActivity;
        }
    }
}
