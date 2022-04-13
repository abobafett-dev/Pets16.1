using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class Pet
    {
        static public int Id { get; set; }
        static public Category Category { get; set; }
        static public Size Size { get; set; }
        static public Wool Wool { get; set; }
        static public String Name { get; set; }
        static public DateTime DateRegistry { get; set; }
        static public DateTime Birthday { get; set; }
        static public String PassportNumber { get; set; }
        static public String OwnerName { get; set; }
        static public List<Vaccination> Vaccinations { get; set; }
        static public List<Photo> Photos { get; set; }
        static public List<VeterinaryActivity> VeterinaryActivities { get; set; }

        public Pet(int id_pet)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_category", 1 },
                    {"id_size", 1 },
                    {"id_wool", 1 },
                    {"name", "Имя" },
                    {"dateRegistry", new DateTime(2022, 04, 13) },
                    {"birthday", new DateTime(2000, 04, 13) },
                    {"passportNumber", "000001" },
                    {"ownerName", "Иванов Иван Иванович" },
                };

            List<Vaccination> vaccinationsToCurrentPetFromDB = new List<Vaccination>() { new Vaccination(1), new Vaccination(2), new Vaccination(3) };
            List<Photo> photosToCurrentPetFromDB = new List<Photo>() { new Photo(1), new Photo(2), new Photo(3) };
            List<VeterinaryActivity> veterinaryActivitiesToCurrentPetFromDB = new List<VeterinaryActivity>() { new VeterinaryActivity(1), new VeterinaryActivity(2), new VeterinaryActivity(3) };

            Id = objectFromDB["id"];
            Category = new Category(objectFromDB["id_category"]);
            Size = new Size(objectFromDB["id_size"]);
            Wool = new Wool(objectFromDB["id_wool"]);
            Vaccinations = vaccinationsToCurrentPetFromDB;
            Photos = photosToCurrentPetFromDB;
            VeterinaryActivities = veterinaryActivitiesToCurrentPetFromDB;
            Name = objectFromDB["name"];
            DateRegistry = objectFromDB["dateRegistry"];
            Birthday = objectFromDB["birthday"];
            PassportNumber = objectFromDB["passportNumber"];
            OwnerName = objectFromDB["ownerName"];
        }
    }
}
