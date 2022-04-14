using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class VeterinaryActivity
    {
        private int pet;
        private int documentOfVeterinaryActivityForPet;
        private int standardVeterinaryActivity;
        public int Id { get; set; }
        public Boolean WasPassed { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public DocumentOfVeterinaryActivityForPet DocumentOfVeterinaryActivityForPet
        {
            get
            {
                return new DocumentOfVeterinaryActivityForPet(documentOfVeterinaryActivityForPet);
            }
        }
        public StandardVeterinaryActivity StandardVeterinaryActivity
        {
            get
            {
                return new StandardVeterinaryActivity(standardVeterinaryActivity);
            }
        }

        public VeterinaryActivity(int id_veterinary_activity)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_pet", 1 },
                    {"id_standard_veterinary_activity", 1 },
                    {"wasPassed", true },
                    {"description", "Обработка от эктопаразитов" },
                    {"date", new DateTime(2022, 04, 13) },
                    {"filePath", "/documentsForVeterinaryActivity/1.docx" },
                };

            Id = objectFromDB["id"];
            pet = objectFromDB["id_pet"];
            standardVeterinaryActivity = objectFromDB["id_standard_veterinary_activity"];
            WasPassed = objectFromDB["wasPassed"];
            Description = objectFromDB["description"];
            Date = objectFromDB["date"];
            documentOfVeterinaryActivityForPet = objectFromDB["id"];
        }
    }
}
