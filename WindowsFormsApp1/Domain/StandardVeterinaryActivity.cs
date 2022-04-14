using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    //Обработка от эктопаразитов
    //Дегельминтизация
    class StandardVeterinaryActivity
    {
        private int veterinaryActivity;
        public int Id { get; set; }
        public String Name { get; set; }
        public VeterinaryActivity VeterinaryActivity
        {
            get
            {
                return new VeterinaryActivity(veterinaryActivity);
            }
        }
        public StandardVeterinaryActivity(int id_standard_veterinary_activity)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_veterinary_activity", 1 },
                    {"name", "Обработка от эктопаразитов" },
                };

            Id = objectFromDB["id"];
            Name = objectFromDB["name"];
            veterinaryActivity = objectFromDB["id_veterinary_activity"];
        }
    }
}
