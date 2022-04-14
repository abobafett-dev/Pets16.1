using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Controllers
{
    class cardOfPet_controller
    {
        public Pet OpenPet(int id_pet)
        {
            Pet pet = new Pet(id_pet);

            return pet;
        }
    }
}
