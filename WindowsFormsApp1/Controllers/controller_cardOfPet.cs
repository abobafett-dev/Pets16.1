using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Controllers
{
    class controller_cardOfPet
    {
        public Pet OpenPet(int id_pet)
        {
            return new Pet(id_pet);
        }
    }
}
