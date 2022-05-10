using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Service;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1.Controllers
{
    class RegistryOfPetsController
    {
        private int petsOnPageCount = 2;
        public Dictionary<string, dynamic> OpenRegistry(int pageNumber, Dictionary<string, dynamic> filtersAndSorts)
        {
            dbPet dbPet = new dbPet();
            var petsInfoFromDB = dbPet.getPets();

            List<Pet> pets = new List<Pet>();

            foreach (var petInfoFromDB in petsInfoFromDB)
            {
                long id_pet = petInfoFromDB.Value["id_pet"];
                long id_category = petInfoFromDB.Value["id_category"];
                long id_gender = petInfoFromDB.Value["id_gender"];
                long id_size = petInfoFromDB.Value["id_size"];
                long id_wool = petInfoFromDB.Value["id_wool"];
                string name = petInfoFromDB.Value["name"];
                DateTime dateRegistry = petInfoFromDB.Value["dateRegistry"];
                DateTime birthday = petInfoFromDB.Value["birthday"];
                string passportNumber = petInfoFromDB.Value["passportNumber"];
                string ownerName = petInfoFromDB.Value["ownerName"];
                string breed = petInfoFromDB.Value["breed"];

                Pet currentPet = new Pet(id_pet, id_gender, id_category, id_size, id_wool, name, breed, dateRegistry, birthday, passportNumber, ownerName);
                pets.Add(currentPet);
            }

            pets = checkFiltersAndSort(pets, filtersAndSorts);

            List<Pet> petsOnPage = new List<Pet>();

            if(pageNumber < 1)
            {
                pageNumber = 1;
            }

            while (pets.Count <= pageNumber * petsOnPageCount - petsOnPageCount)
            {
                pageNumber--;
            }

            var firstElementOnPage = pageNumber * petsOnPageCount - petsOnPageCount + 1;
            var lastELementOnPage = pageNumber * petsOnPageCount;

            for (var i = 0; i < pets.Count; i++) 
            {
                if (i+1 >= firstElementOnPage && i+1 <= lastELementOnPage)
                {
                    petsOnPage.Add(pets[i]);
                }
            }

            return new Dictionary<string, dynamic>
            {
                {"pets", petsOnPage },
                {"pageNumber", pageNumber },
            };
        }


        public void ExportExcel(Dictionary<string, dynamic> filtersAndSorts)
        {
            dbPet dbPet = new dbPet();
            var petsInfoFromDB = dbPet.getPets();

            List<Pet> pets = new List<Pet>();

            foreach (var petInfoFromDB in petsInfoFromDB)
            {
                long id_pet = petInfoFromDB.Value["id_pet"];
                long id_category = petInfoFromDB.Value["id_category"];
                long id_gender = petInfoFromDB.Value["id_gender"];
                long id_size = petInfoFromDB.Value["id_size"];
                long id_wool = petInfoFromDB.Value["id_wool"];
                string name = petInfoFromDB.Value["name"];
                DateTime dateRegistry = petInfoFromDB.Value["dateRegistry"];
                DateTime birthday = petInfoFromDB.Value["birthday"];
                string passportNumber = petInfoFromDB.Value["passportNumber"];
                string ownerName = petInfoFromDB.Value["ownerName"];
                string breed = petInfoFromDB.Value["breed"];

                Pet currentPet = new Pet(id_pet, id_gender, id_category, id_size, id_wool, name, breed, dateRegistry, birthday, passportNumber, ownerName);
                pets.Add(currentPet);
            }

            pets = checkFiltersAndSort(pets, filtersAndSorts);

            Excel.Application excel = new Excel.Application();
            //excel.Visible = true;

            excel.SheetsInNewWorkbook = 1;
            Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
            excel.DisplayAlerts = false;

            Excel.Worksheet sheetFirst = (Excel.Worksheet)excel.Worksheets.get_Item(1);
            sheetFirst.Name = "Реестр животных";

            sheetFirst.Cells[1, 1] = "Категория";
            sheetFirst.Cells[1, 2] = "Имя";
            sheetFirst.Cells[1, 3] = "Дата рождения";
            sheetFirst.Cells[1, 4] = "Порода";
            sheetFirst.Cells[1, 5] = "Дата регистрации";
            sheetFirst.Cells[1, 6] = "Номер паспорта";
            sheetFirst.Cells[1, 7] = "ФИО владельца";

            int currentRow = 2;
            foreach (Pet pet in pets)
            {
                sheetFirst.Cells[currentRow,1] = pet.Category.Name;
                sheetFirst.Cells[currentRow,2] = pet.Name;
                sheetFirst.Cells[currentRow,3] = pet.Birthday;
                sheetFirst.Cells[currentRow,4] = pet.Breed;
                sheetFirst.Cells[currentRow,5] = pet.DateRegistry;
                sheetFirst.Cells[currentRow,6] = pet.PassportNumber;
                sheetFirst.Cells[currentRow,7] = pet.OwnerName;
                currentRow++;
            }

            sheetFirst.Cells.EntireColumn.AutoFit();
            sheetFirst.Cells.EntireRow.AutoFit();
            sheetFirst.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                excel.Application.ActiveWorkbook.SaveAs(sfd.FileName, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlShared,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            excel.Application.ActiveWorkbook.Close();
            excel.Application.Quit();
        }
        private List<Pet> checkFiltersAndSort(List<Pet> pets, Dictionary<string, dynamic> filtersAndSorts)
        {
            List<Pet> petsWithFilters = new List<Pet>();
            foreach (Pet currentPet in pets)
            {
                if (filtersAndSorts.ContainsKey("category") && filtersAndSorts["category"] != "" && currentPet.Category.Name != filtersAndSorts["category"])
                {
                    continue;
                }

                if (filtersAndSorts.ContainsKey("breed") && filtersAndSorts["breed"] != "" && !currentPet.Breed.ToLower().Contains(filtersAndSorts["breed"].ToLower()))
                {
                    continue;
                }

                if (filtersAndSorts.ContainsKey("petName") && filtersAndSorts["petName"] != "" && !currentPet.Name.ToLower().Contains(filtersAndSorts["petName"].ToLower()))
                {
                    continue;
                }

                if (filtersAndSorts.ContainsKey("passportNumber") && filtersAndSorts["passportNumber"] != "" && !currentPet.PassportNumber.ToLower().Contains(filtersAndSorts["passportNumber"].ToLower()))
                {
                    continue;
                }

                if (filtersAndSorts.ContainsKey("ownerName") && filtersAndSorts["ownerName"] != "" && !currentPet.OwnerName.ToLower().Contains(filtersAndSorts["ownerName"].ToLower()))
                {
                    continue;
                }

                if (filtersAndSorts.ContainsKey("dateRegistryFrom") && (filtersAndSorts["dateRegistryFrom"] < currentPet.DateRegistry || filtersAndSorts["dateRegistryTo"] > currentPet.DateRegistry))
                {
                    continue;
                }


                if (filtersAndSorts.ContainsKey("birthdayFrom") && (filtersAndSorts["birthdayFrom"] < currentPet.Birthday || filtersAndSorts["birthdayTo"] > currentPet.Birthday))
                {
                    continue;
                }

                petsWithFilters.Add(currentPet);
            }


            if (filtersAndSorts.ContainsKey("sortColumn") && filtersAndSorts.ContainsKey("sortType") && filtersAndSorts["sortColumn"] != "" && filtersAndSorts["sortType"] != "")
            {
                if (filtersAndSorts["sortType"] == "Возрастанию")
                {
                    if (filtersAndSorts["sortColumn"] == "Категория")
                    {
                        petsWithFilters.Sort((a, b) => a.Category.Name.CompareTo(b.Category.Name));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Имя")
                    {
                        petsWithFilters.Sort((a, b) => a.Name.CompareTo(b.Name));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Дата регистрации")
                    {
                        petsWithFilters.Sort((a, b) => a.DateRegistry.CompareTo(b.DateRegistry));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Дата рождения")
                    {
                        petsWithFilters.Sort((a, b) => a.Birthday.CompareTo(b.Birthday));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Порода")
                    {
                        petsWithFilters.Sort((a, b) => a.Breed.CompareTo(b.Breed));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Номер паспорта")
                    {
                        petsWithFilters.Sort((a, b) => a.PassportNumber.CompareTo(b.PassportNumber));
                    }
                    else if (filtersAndSorts["sortColumn"] == "ФИО владельца")
                    {
                        petsWithFilters.Sort((a, b) => a.OwnerName.CompareTo(b.OwnerName));
                    }
                }
                else if (filtersAndSorts["sortType"] == "Убыванию")
                {
                    if (filtersAndSorts["sortColumn"] == "Категория")
                    {
                        petsWithFilters.Sort((a, b) => b.Category.Name.CompareTo(a.Category.Name));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Имя")
                    {
                        petsWithFilters.Sort((a, b) => b.Name.CompareTo(a.Name));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Дата регистрации")
                    {
                        petsWithFilters.Sort((a, b) => b.DateRegistry.CompareTo(a.DateRegistry));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Дата рождения")
                    {
                        petsWithFilters.Sort((a, b) => b.Birthday.CompareTo(a.Birthday));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Порода")
                    {
                        petsWithFilters.Sort((a, b) => b.Breed.CompareTo(a.Breed));
                    }
                    else if (filtersAndSorts["sortColumn"] == "Номер паспорта")
                    {
                        petsWithFilters.Sort((a, b) => b.PassportNumber.CompareTo(a.PassportNumber));
                    }
                    else if (filtersAndSorts["sortColumn"] == "ФИО владельца")
                    {
                        petsWithFilters.Sort((a, b) => b.OwnerName.CompareTo(a.OwnerName));
                    }
                }
            }

            return petsWithFilters;
        }
    }
}
