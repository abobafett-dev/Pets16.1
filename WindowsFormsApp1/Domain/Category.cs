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
        static public int Id { get; set; }
        static public String Name { get; set; }
        public Category(int id_category)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"name", "кошка" },
                };

            Id = objectFromDB["id"];
            Name = objectFromDB["name"];
        }
    }
}
