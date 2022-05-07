using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Controllers
{
    class RegistryOfPetsController
    {
        public List<Pet> OpenRegistry()
        {
            dbPet dbPet = new dbPet();
            var petsInfoFromDB = dbPet.getPets();

            List<Pet> pets = new List<Pet>();

            foreach (var petInfoFromDB in petsInfoFromDB)
            {
                long id_pet = petInfoFromDB.Value["id_pet"];
                long id_category = petInfoFromDB.Value["id_category"];
                long id_gender = petInfoFromDB.Value["id_gender"];
                long id_size = petInfoFromDB.Value["id_size"];
                long id_wool = petInfoFromDB.Value["id_wool"];
                string name = petInfoFromDB.Value["name"];
                DateTime dateRegistry = petInfoFromDB.Value["dateRegistry"];
                DateTime birthday = petInfoFromDB.Value["birthday"];
                string passportNumber = petInfoFromDB.Value["passportNumber"];
                string ownerName = petInfoFromDB.Value["ownerName"];
                string breed = petInfoFromDB.Value["breed"];

                Pet currentPet = new Pet(id_pet, id_gender, id_category, id_size, id_wool, name, breed, dateRegistry, birthday, passportNumber, ownerName);

                pets.Add(currentPet);
            }

            return pets;
        }

        public List<Pet> ExportExcel()
        {
            List<Pet> pets = new List<Pet>();
            pets.Add(new Pet(1));
            pets.Add(new Pet(2));
            pets.Add(new Pet(3));

            return pets;
        }
    }
}
