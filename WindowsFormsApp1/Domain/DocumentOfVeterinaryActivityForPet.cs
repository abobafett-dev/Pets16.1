using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class DocumentOfVeterinaryActivityForPet
    {
        private int pet;
        private int veterinaryActivity;
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public VeterinaryActivity VeterinaryActivity
        {
            get
            {
                return new VeterinaryActivity(veterinaryActivity);
            }
        }
        public String FilePath { get; set; }
        public DocumentOfVeterinaryActivityForPet(int id_veterinaryActivity)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id_veterinaryActivity", 1 },
                    { "id_pet", 1 }, 
                    {"filePath", "exampleDoc" },
                };

            veterinaryActivity = objectFromDB["id_veterinaryActivity"];
            pet = objectFromDB["id_pet"];
            FilePath = objectFromDB["filePath"];
        }

    }
}
