using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Domain
{
    class Pet
    {
        private long gender;
        private long category;
        private long size;
        private long wool;
        private Dictionary<dynamic, dynamic> vaccinations;
        private Dictionary<dynamic, dynamic> photos;
        private Dictionary<dynamic, dynamic> veterinaryActivities;
        private Dictionary<dynamic, dynamic> documentsOfVeterinaryActivities;
        public Gender Gender
        {
            get
            {
                return new Gender(gender, Id);
            }
        }
        public Category Category
        {
            get
            {
                return new Category(category, Id, gender);
            }
        }
        public Size Size
        {
            get
            {
                return new Size(size, Id);
            }
        }
        public Wool Wool
        {
            get
            {
                return new Wool(wool, Id);
            }
        }
        public Dictionary<long, Vaccination> Vaccinations
        {
            get
            {
                Dictionary<long, Vaccination> currentVaccinations = new Dictionary<long, Vaccination>();
                foreach (var vaccination in vaccinations)
                {
                    var vaccinationInfo = vaccination.Value;
                    var id_pet = vaccinationInfo["id_pet"];
                    var id_vaccination = vaccinationInfo["id_vaccination"];
                    var name_vaccination = vaccinationInfo["name_vaccination"];
                    var date_vaccination = vaccinationInfo["date_vaccination"];

                    Vaccination currentVaccination = new Vaccination(id_pet, id_vaccination, name_vaccination, date_vaccination);
                    currentVaccinations.Add(id_vaccination, currentVaccination);
                }
                return currentVaccinations;
            }
        }
        public Dictionary<long, Photo> Photos
        {
            get
            {
                Dictionary<long, Photo> currentPhotos = new Dictionary<long, Photo>();
                foreach (var photo in photos)
                {
                    //var photoInfo = photo.Value;
                    var photoPet = (Dictionary<dynamic, dynamic>)photo.Value;
                    var id_pet = photo.Key;
                    var id_photo = photoPet.First().Key;
                    var filePath = photoPet.First().Value;

                    Photo currentPhoto = new Photo(id_photo, filePath, id_pet);
                    currentPhotos.Add(id_photo, currentPhoto);
                }
                return currentPhotos;
            }
        }
        public Dictionary<bool, Dictionary<long, VeterinaryActivity>> VeterinaryActivities
        {
            get
            {
                Dictionary<bool, Dictionary<long, VeterinaryActivity>> currentVeterinaryActivities = new Dictionary<bool, Dictionary<long, VeterinaryActivity>>();
                foreach (var veterinaryActivities in veterinaryActivities)
                {
                    foreach (var veterinaryActivity in veterinaryActivities.Value)
                    {
                        if (!currentVeterinaryActivities.ContainsKey(veterinaryActivities.Key))
                        {
                            currentVeterinaryActivities.Add(veterinaryActivities.Key, new Dictionary<long, VeterinaryActivity>());
                        }

                        var id_veterinaryActivity = veterinaryActivity.Value["id_veterinaryActivity"];
                        var id_pet = veterinaryActivity.Value["id_pet"];
                        var description_veterinaryActivity = veterinaryActivity.Value["description_veterinaryActivity"];
                        var date_veterinaryActivity = veterinaryActivity.Value["date_veterinaryActivity"];
                        var filePath_veterinaryActivity = veterinaryActivity.Value["filePath_veterinaryActivity"];
                        var id_standardVeterinaryActivity = veterinaryActivity.Value["id_standardVeterinaryActivity"];
                        var name_standardVeterinaryActivity = veterinaryActivity.Value["name_standardVeterinaryActivity"];

                        var currentVeterinaryActivity = new VeterinaryActivity(id_veterinaryActivity, id_pet, id_standardVeterinaryActivity, veterinaryActivities.Key, description_veterinaryActivity, date_veterinaryActivity, filePath_veterinaryActivity);

                        currentVeterinaryActivities[veterinaryActivities.Key].Add(id_veterinaryActivity, currentVeterinaryActivity);

                    }
                }
                return currentVeterinaryActivities;
            }
        }
        public Dictionary<long, DocumentOfVeterinaryActivityForPet> DocumentsOfVeterinaryActivities
        {
            get
            {
                Dictionary<long, DocumentOfVeterinaryActivityForPet> currentDocuments = new Dictionary<long, DocumentOfVeterinaryActivityForPet>();
                foreach (var veterinaryActivity in documentsOfVeterinaryActivities)
                {
                    var id_veterinaryActivity = veterinaryActivity.Key;
                    var id_pet = veterinaryActivity.Value["id_pet"];
                    var description_veterinaryActivity = veterinaryActivity.Value["description_veterinaryActivity"];
                    var date_veterinaryActivity = veterinaryActivity.Value["date_veterinaryActivity"];
                    var filePath_veterinaryActivity = veterinaryActivity.Value["filePath_veterinaryActivity"];
                    var id_standardVeterinaryActivity = veterinaryActivity.Value["id_standardVeterinaryActivity"];
                    var name_standardVeterinaryActivity = veterinaryActivity.Value["name_standardVeterinaryActivity"];
                    var wasPassed_veterinaryActivity = veterinaryActivity.Value["wasPassed_veterinaryActivity"];

                    var currentDocumentOfVeterinaryActivity = new DocumentOfVeterinaryActivityForPet(id_veterinaryActivity, id_pet, id_standardVeterinaryActivity, wasPassed_veterinaryActivity, description_veterinaryActivity, date_veterinaryActivity, filePath_veterinaryActivity);

                    currentDocuments.Add(id_veterinaryActivity, currentDocumentOfVeterinaryActivity);
                }
                return currentDocuments;
            }
        }
        public long Id { get; set; }
        public String Name { get; set; }
        public String Breed { get; set; }
        public DateTime DateRegistry { get; set; }
        public DateTime Birthday { get; set; }
        public String PassportNumber { get; set; }
        public String OwnerName { get; set; }

        public Pet(long id_pet)
        {
            dbPet dbPet = new dbPet();
            var petInfoFromDB = dbPet.getPet(id_pet);

            dbVaccination dbVaccination = new dbVaccination();
            var vaccinationsOfPetInfoFromDB = dbVaccination.getVaccinationsOfPet(id_pet);
            dbPhoto dbPhoto = new dbPhoto();
            var photosOfPetInfoFromDB = dbPhoto.getPhotosOfPet(id_pet);
            dbVeterinaryActivity dbVeterinaryActivity = new dbVeterinaryActivity();
            var veterinaryActivitiesOfPetInfoFromDB = dbVeterinaryActivity.getVeterinaryActivitiesOfPet(id_pet);
            var documentsOfPetInfoFromDB = dbVeterinaryActivity.getDocumentsOfPet(id_pet);

            //Dictionary<String, dynamic> objectFromDB =
            //    new Dictionary<string, dynamic>
            //    {
            //        { "id", 1 },
            //        {"id_category", 1 },
            //        {"id_size", 1 },
            //        {"id_wool", 1 },
            //        {"name", "Имя" },
            //        {"breed", "Шотландская вислоухая" },
            //        {"dateRegistry", new DateTime(2022, 04, 13) },
            //        {"birthday", new DateTime(2000, 04, 13) },
            //        {"passportNumber", "000001" },
            //        {"ownerName", "Иванов Иван Иванович" },
            //    };

            //var vaccinationsToCurrentPetFromDB = new List<int>() { 1,2,3 };
            //var photosToCurrentPetFromDB = new List<int>() { 1, 2, 3 };
            //var veterinaryActivitiesToCurrentPetFromDB = new List<int>() { 1, 2, 3 };
            //var documentOfVeterinaryActivityForPetsFromDB = new List<int>() { 1, 2, 3 };

            Id = petInfoFromDB["id_pet"];
            gender = petInfoFromDB["id_gender"];
            category = petInfoFromDB["id_category"];
            size = petInfoFromDB["id_size"];
            wool = petInfoFromDB["id_wool"];
            Name = petInfoFromDB["name"];
            Breed = petInfoFromDB["breed"];
            DateRegistry = petInfoFromDB["dateRegistry"];
            Birthday = petInfoFromDB["birthday"];
            PassportNumber = petInfoFromDB["passportNumber"];
            OwnerName = petInfoFromDB["ownerName"];


            this.vaccinations = vaccinationsOfPetInfoFromDB;
            this.photos = photosOfPetInfoFromDB;
            this.veterinaryActivities = veterinaryActivitiesOfPetInfoFromDB;
            this.documentsOfVeterinaryActivities = documentsOfPetInfoFromDB;
        }

        public Pet(long id_pet, long id_gender, long id_category, long id_size, long id_wool, string name, string breed, DateTime dateRegistry, DateTime birthday, string passportNumber, string ownerName)
        {

            dbVaccination dbVaccination = new dbVaccination();
            var vaccinationsOfPetInfoFromDB = dbVaccination.getVaccinationsOfPet(id_pet);
            dbPhoto dbPhoto = new dbPhoto();
            var photosOfPetInfoFromDB = dbPhoto.getPhotosOfPet(id_pet);
            dbVeterinaryActivity dbVeterinaryActivity = new dbVeterinaryActivity();
            var veterinaryActivitiesOfPetInfoFromDB = dbVeterinaryActivity.getVeterinaryActivitiesOfPet(id_pet);
            var documentsOfPetInfoFromDB = dbVeterinaryActivity.getDocumentsOfPet(id_pet);

            Id = id_pet;
            gender = id_gender;
            category = id_category;
            size = id_size;
            wool = id_wool;
            Name = name;
            Breed = breed;
            DateRegistry = dateRegistry;
            Birthday = birthday;
            PassportNumber = passportNumber;
            OwnerName = ownerName;


            this.vaccinations = vaccinationsOfPetInfoFromDB;
            this.photos = photosOfPetInfoFromDB;
            this.veterinaryActivities = veterinaryActivitiesOfPetInfoFromDB;
            this.documentsOfVeterinaryActivities = documentsOfPetInfoFromDB;
        }
    }
}
