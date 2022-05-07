using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Domain
{
    //Шерсть короткошерстная
    //Шерсть длинношерстная
    //Шерсть жесткошерстная
    //Шерсть кудрявая
    class Wool
    {
        private long pet;
        public long Id { get; set; }
        public String Name { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }

        public Wool(long id_wool, long id_pet)
        {
            dbWool dbWool = new dbWool();
            var woolInfoFromDB = dbWool.getWool(id_wool);

            Id = woolInfoFromDB.First().Key;
            pet = id_pet;
            Name = woolInfoFromDB.First().Value;
        }
    }
}
