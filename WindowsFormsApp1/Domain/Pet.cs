using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class Pet
    {
        private int category;
        private int size;
        private int wool;
        private List<int> vaccinations;
        private List<int> photos;
        private List<int> veterinaryActivities;
        private List<int> documentOfVeterinaryActivityForPets;
        public Category Category
        {
            get
            {
                return new Category(category);
            }
        }
        public Size Size
        {
            get
            {
                return new Size(size);
            }
        }
        public Wool Wool
        {
            get
            {
                return new Wool(wool);
            }
        }
        public List<Vaccination> Vaccinations
        {
            get
            {
                var listOfVaccinations = new List<Vaccination>();
                foreach (var vaccination in vaccinations)
                {
                    listOfVaccinations.Add(new Vaccination(vaccination));
                }
                return listOfVaccinations;
            }
        }
        public List<Photo> Photos
        {
            get
            {
                var listOfPhotos = new List<Photo>();
                foreach (var photo in photos)
                {
                    listOfPhotos.Add(new Photo(photo));
                }
                return listOfPhotos;
            }
        }
        public List<VeterinaryActivity> VeterinaryActivities
        {
            get
            {
                var listOfVeterinaryActivities = new List<VeterinaryActivity>();
                foreach (var veterinaryActivity in veterinaryActivities)
                {
                    listOfVeterinaryActivities.Add(new VeterinaryActivity(veterinaryActivity));
                }
                return listOfVeterinaryActivities;
            }
        }
        public List<DocumentOfVeterinaryActivityForPet> DocumentOfVeterinaryActivityForPets
        {
            get
            {
                var listOfDocumentOfVeterinaryActivityForPets = new List<DocumentOfVeterinaryActivityForPet>();
                foreach (var documentOfVeterinaryActivityForPet in documentOfVeterinaryActivityForPets)
                {
                    listOfDocumentOfVeterinaryActivityForPets.Add(new DocumentOfVeterinaryActivityForPet(documentOfVeterinaryActivityForPet));
                }
                return listOfDocumentOfVeterinaryActivityForPets;
            }
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Breed { get; set; }
        public DateTime DateRegistry { get; set; }
        public DateTime Birthday { get; set; }
        public String PassportNumber { get; set; }
        public String OwnerName { get; set; }

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
                    {"breed", "Шотландская вислоухая" },
                    {"dateRegistry", new DateTime(2022, 04, 13) },
                    {"birthday", new DateTime(2000, 04, 13) },
                    {"passportNumber", "000001" },
                    {"ownerName", "Иванов Иван Иванович" },
                };

            var vaccinationsToCurrentPetFromDB = new List<int>() { 1,2,3 };
            var photosToCurrentPetFromDB = new List<int>() { 1, 2, 3 };
            var veterinaryActivitiesToCurrentPetFromDB = new List<int>() { 1, 2, 3 };
            var documentOfVeterinaryActivityForPetsFromDB = new List<int>() { 1, 2, 3 };

            Id = objectFromDB["id"];
            category = objectFromDB["id_category"];
            size = objectFromDB["id_size"];
            wool = objectFromDB["id_wool"];
            vaccinations = vaccinationsToCurrentPetFromDB;
            photos = photosToCurrentPetFromDB;
            veterinaryActivities = veterinaryActivitiesToCurrentPetFromDB;
            documentOfVeterinaryActivityForPets = documentOfVeterinaryActivityForPetsFromDB;
            Name = objectFromDB["name"];
            Breed = objectFromDB["breed"];
            DateRegistry = objectFromDB["dateRegistry"];
            Birthday = objectFromDB["birthday"];
            PassportNumber = objectFromDB["passportNumber"];
            OwnerName = objectFromDB["ownerName"];
        }
    }
}
