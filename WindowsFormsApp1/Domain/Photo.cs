using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Domain
{
    class Photo
    {
        public long Id { get; set; }
        private long pet;
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public String FilePath { get; set; }

        public Photo(long id_photo,string filePath, long id_pet)
        {

            Id = id_photo;
            pet = id_pet;
            FilePath = filePath;
;
        }
    }
}
