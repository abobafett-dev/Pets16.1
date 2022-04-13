using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
//Размер животного маленькое
//Размер животного среднее
//Размер животного большое
    class Size
    {
        static public int Id { get; set; }
        static public String Name { get; set; }

        public Size(int id_size)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"name", "маленькое" },
                };

            Id = objectFromDB["id"];
            Name = objectFromDB["name"];
        }
    }
}
