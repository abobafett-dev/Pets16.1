using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class DocumentOfVeterinaryActivityForPet
    {
        private long pet;
        private long veterinaryActivity;
        private long id_standardVeterinaryActivity;
        private bool wasPassed;
        private string description;
        private DateTime date;
        private string filePath;
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public VeterinaryActivity VeterinaryActivity
        {
            get
            {
                return new VeterinaryActivity(veterinaryActivity, pet, id_standardVeterinaryActivity, wasPassed, description, date, filePath);
            }
        }
        public String FilePath { get; set; }
        public DocumentOfVeterinaryActivityForPet(long id_veterinaryActivity, long id_pet, long id_standardVeterinaryActivity, bool wasPassed, string description, DateTime date, string filePath)
        {
            veterinaryActivity = id_veterinaryActivity;
            pet = id_pet;
            FilePath = filePath;
            this.id_standardVeterinaryActivity = id_standardVeterinaryActivity;
            this.wasPassed = wasPassed;
            this.description = description;
            this.date = date;
            this.filePath = filePath;
        }

    }
}
