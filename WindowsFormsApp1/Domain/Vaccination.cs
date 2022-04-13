using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
//Против бешенства собака, кошка
//Против чумы собака
//Против парвовирусного энтерита собака
//Против аденовироза собака
//Против парагриппа собака
//Против лептоспироза кошка
//Против панлейкопении кошка
//Против калицивироза кошка
//Против герпесвирусной инфекции кошка
//Против хламидиоза кошка
    class Vaccination
    {
        static public int Id { get; set; }
        //static public Pet Pet { get; set; }
        static public String Name { get; set; }
        static public DateTime Date { get; set; }

        public Vaccination(int id_vaccination)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_pet", 1 },
                    {"name", "Против бешенства" },
                    {"date", new DateTime(2022, 04, 13) },
                };

            Id = objectFromDB["id"];
            //Pet = new Pet(objectFromDB["id_pet"]);
            Name = objectFromDB["name"];
            Date = objectFromDB["date"];
        }
    }
}
