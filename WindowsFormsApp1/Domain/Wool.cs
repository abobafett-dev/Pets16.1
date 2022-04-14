using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    //Шерсть короткошерстная
    //Шерсть длинношерстная
    //Шерсть жесткошерстная
    //Шерсть кудрявая
    class Wool
    {
        private int pet;
        public int Id { get; set; }
        public String Name { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }

        public Wool(int id_wool)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    { "id_pet", 1 },
                    {"name", "короткошерстная" },
                };

            Id = objectFromDB["id"];
            pet = objectFromDB["id_pet"];
            Name = objectFromDB["name"];
        }
    }
}
