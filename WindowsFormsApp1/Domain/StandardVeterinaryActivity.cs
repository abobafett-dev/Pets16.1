using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1.Domain
{
    //Обработка от эктопаразитов
    //Дегельминтизация
    class StandardVeterinaryActivity
    {
        private long veterinaryActivity;
        private long id_pet;
        private bool wasPassed;
        private string description;
        private DateTime date;
        private string filePath;
        public long Id { get; set; }
        public String Name { get; set; }
        public VeterinaryActivity VeterinaryActivity
        {
            get
            {
                return new VeterinaryActivity(veterinaryActivity, id_pet, Id, wasPassed, description, date, filePath);
            }
        }
        public StandardVeterinaryActivity(long id_veterinaryActivity, long id_pet, long id_standardVeterinaryActivity, bool wasPassed, string description, DateTime date, string filePath)
        {
            dbStandardVeterinaryActivity dbStandardVeterinaryActivity = new dbStandardVeterinaryActivity();
            var currentStandardVeterinaryActivity = dbStandardVeterinaryActivity.getStandardVeterinaryActivity(id_standardVeterinaryActivity); 


            Id = currentStandardVeterinaryActivity.First().Key;
            Name = currentStandardVeterinaryActivity.First().Value;
            veterinaryActivity = id_veterinaryActivity;
            this.id_pet = id_pet;
            this.wasPassed = wasPassed;
            this.description = description;
            this.date = date;
            this.filePath = filePath;
        }
    }
}
