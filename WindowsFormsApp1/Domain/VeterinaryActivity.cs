using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class VeterinaryActivity
    {
        private long pet;
        private long standardVeterinaryActivity;
        private string filePath;
        public long Id { get; set; }
        public Boolean WasPassed { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public Pet Pet
        {
            get
            {
                return new Pet(pet);
            }
        }
        public DocumentOfVeterinaryActivityForPet DocumentOfVeterinaryActivityForPet
        {
            get
            {
                return new DocumentOfVeterinaryActivityForPet(Id, pet, standardVeterinaryActivity, WasPassed, Description, Date, filePath);
            }
        }
        public StandardVeterinaryActivity StandardVeterinaryActivity
        {
            get
            {
                return new StandardVeterinaryActivity(Id, pet, standardVeterinaryActivity, WasPassed, Description, Date, filePath);
            }
        }

        public VeterinaryActivity(long id_veterinaryActivity, long id_pet, long id_standardVeterinaryActivity, bool wasPassed, string description, DateTime date, string filePath)
        {
            Id = id_veterinaryActivity;
            pet = id_pet;
            standardVeterinaryActivity = id_standardVeterinaryActivity;
            WasPassed = wasPassed;
            Description = description;
            Date = date;
            this.filePath = filePath;
        }
    }
}
