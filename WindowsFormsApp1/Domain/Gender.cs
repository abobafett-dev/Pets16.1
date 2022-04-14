using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    //Пол животного кобель
    //Пол животного сука
    //Пол животного кот
    //Пол животного кошка
    class Gender
    {
        private int category;
        public int Id { get; set; }
        public Category Category
        {
            get
            {
                return new Category(category);
            }
        }
        public String Name { get; set; }

        public Gender(int id_gender)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_category", 1 },
                    {"name", "кот" },
                };

            Id = objectFromDB["id"];
            category = objectFromDB["id_category"];
            Name = objectFromDB["name"];
        }
    }
}
