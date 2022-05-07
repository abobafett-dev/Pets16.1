using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Domain
{
    //Пол животного кобель
    //Пол животного сука
    //Пол животного кот
    //Пол животного кошка
    class Gender
    {
        private long category;
        private long pet;
        public long Id { get; set; }
        public Category Category
        {
            get
            {
                return new Category(category, pet, Id);
            }
        }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public String Name { get; set; }

        public Gender(long id_gender, long id_pet)
        {
            dbGender dbGender = new dbGender();
            var genderInfoFromDB = dbGender.getGender(id_gender);

            category = genderInfoFromDB.First().Key;
            pet = id_pet;
            var gender = (Dictionary<dynamic, dynamic>)genderInfoFromDB[category];
            Id = gender.First().Key;
            Name = genderInfoFromDB[category][Id];
        }
    }
}
