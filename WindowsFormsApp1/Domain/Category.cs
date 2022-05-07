using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Domain
{
    //Категория животного собака
    //Категория животного кошка
    class Category
    {
        private long gender;
        private long pet;
        public long Id { get; set; }
        public String Name { get; set; }
        public Gender Gender
        {
            get
            {
                return new Gender(gender, pet);
            }
        }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }

        public Category(long id_category, long id_pet, long id_gender)
        {
            var categoryFromDB = new dbCategory().getCategory(id_category);

            pet = id_pet;
            gender = id_gender;
            Id = categoryFromDB.First().Key;
            Name = categoryFromDB.First().Value;
        }
    }
}
