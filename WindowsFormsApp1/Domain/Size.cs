using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Domain
{
//Размер животного маленькое
//Размер животного среднее
//Размер животного большое
    class Size
    {
        private static long pet;
        public long Id { get; set; }
        public String Name { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }

        public Size(long id_size, long id_pet)
        {
            dbSize dbSize = new dbSize();
            var sizeFromDB = dbSize.getSize(id_size);
            Id = sizeFromDB.First().Key;
            pet = id_pet;
            Name = sizeFromDB.First().Value;
        }
    }
}
