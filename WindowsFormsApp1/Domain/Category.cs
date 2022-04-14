using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    //Категория животного собака
    //Категория животного кошка
    class Category
    {
        private int gender;
        private int pet;
        public int Id { get; set; }
        public String Name { get; set; }
        public Gender Gender
        {
            get
            {
                return new Gender(gender);
            }
        }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public Category(int id_category)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    { "id_gender", 1 },
                    { "id_pet", 1 },
                    {"name", "кошка" },
                };

            Id = objectFromDB["id"];
            gender = objectFromDB["id_gender"];
            pet = objectFromDB["id_pet"];
            Name = objectFromDB["name"];
        }
    }
}
