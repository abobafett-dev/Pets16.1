using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Controllers
{
    class CardOfPetController
    {
        public Pet OpenPet(long id_pet)
        {
            Pet pet = new Pet(id_pet);

            return pet;
        }

        public Pet ExportExcel(int id_pet)
        {
            return new Pet(id_pet);
        }

        public Pet ExportWord(int id_pet)
        {
            return new Pet(id_pet);
        }
    }
}
