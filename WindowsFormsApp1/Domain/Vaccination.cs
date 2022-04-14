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
        private int pet;
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }

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
            pet = objectFromDB["id_pet"];
            Name = objectFromDB["name"];
            Date = objectFromDB["date"];
        }
    }
}
