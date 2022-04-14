using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Controllers
{
    class registryOfPets_controller
    {
        public List<Pet> OpenRegistry()
        {
            List<Pet> pets = new List<Pet>();
            pets.Add(new Pet(1));
            pets.Add(new Pet(2));
            pets.Add(new Pet(3));

            return pets;
        }
    }
}
