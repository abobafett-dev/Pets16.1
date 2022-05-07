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
        private long pet;
        public long Id { get; set; }
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }

        public Vaccination(long id_pet, long id_vaccination,string name_vaccination,DateTime date_vaccination)
        {
            Id = id_vaccination;
            pet = id_pet;
            Name = name_vaccination;
            Date = date_vaccination;
        }
    }
}
