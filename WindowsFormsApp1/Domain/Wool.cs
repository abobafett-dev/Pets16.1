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
        public static int Id{ get; set; }

        public static String Name { get; set; }

        public Wool(int id_wool)
        {
            Dictionary<String, dynamic> objectFromDB = 
                new Dictionary<string, dynamic> 
                { 
                    { "id", 1 },
                    {"name", "короткошерстная" },
                };

            Id = objectFromDB["id"];
            Name = objectFromDB["name"];
        }
    }
}
