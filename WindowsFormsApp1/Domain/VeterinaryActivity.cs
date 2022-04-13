using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
//Обработка от эктопаразитов
//Дегельминтизация
    class VeterinaryActivity
    {
        static public int Id { get; set; }
        //static public Pet Pet { get; set; }
        static public Boolean WasPassed { get; set; }
        static public String Description { get; set; }
        static public DateTime Date { get; set; }
        static public String FilePath { get; set; }

        public VeterinaryActivity(int id_veterinary_activity)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_pet", 1 },
                    {"wasPassed", false },
                    {"description", "Обработка от эктопаразитов" },
                    {"date", new DateTime(2022, 04, 13) },
                    {"filePath", "/documentsForVeterinaryActivity/1.docx" },
                };

            Id = objectFromDB["id"];
            //Pet = new Pet(objectFromDB["id_pet"]);
            WasPassed = objectFromDB["wasPassed"];
            Description = objectFromDB["description"];
            Date = objectFromDB["date"];
            FilePath = objectFromDB["filePath"];
        }
    }
}
