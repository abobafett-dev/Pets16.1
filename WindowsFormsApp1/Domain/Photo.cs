using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    class Photo
    {
        static public int Id { get; set; }
        //static public Pet Pet { get; set; }
        static public String FilePath { get; set; }

        public Photo(int id_photo)
        {
            Dictionary<String, dynamic> objectFromDB =
                new Dictionary<string, dynamic>
                {
                    { "id", 1 },
                    {"id_pet", 1 },
                    {"filePath", "/photoForPet/1.docx" },
                };

            Id = objectFromDB["id"];
            //Pet = new Pet(objectFromDB["id_pet"]);
            FilePath = objectFromDB["filePath"];
        }
    }
}
