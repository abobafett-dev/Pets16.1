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
        static public int Id { get; set; }
        static public Category Category { get; set; }
        static public String Name { get; set; }

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
            Category = new Category(objectFromDB["id_category"]);
            Name = objectFromDB["name"];
        }
    }
}
