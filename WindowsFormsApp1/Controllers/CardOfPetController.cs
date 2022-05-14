using System;
using WindowsFormsApp1.Domain;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1.Controllers
{
    class CardOfPetController
    {
        public Pet OpenPet(long id_pet)
        {
            Pet pet = new Pet(id_pet);

            return pet;
        }

        public void DownloadDoc(string filePath)
        {

            var s = Properties.Resources.ResourceManager.GetObject(filePath);
            var file = (byte[])Properties.Resources.ResourceManager.GetObject(filePath);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "docx files (*.docx)|*.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, file);

                MessageBox.Show("Файл успешно сохранен!");
            }
        }

        public void ExportExcel(int id_pet)
        {
            Pet pet = new Pet(id_pet);


            Excel.Application excel = new Excel.Application();

            excel.SheetsInNewWorkbook = 5;
            Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
            excel.DisplayAlerts = false;


            Excel.Worksheet sheetFirst = (Excel.Worksheet)excel.Worksheets.get_Item(1);
            sheetFirst.Name = "Характеристики животного";

            sheetFirst.Cells[1, 1] = "Имя";
            sheetFirst.Cells[2, 1] = "Категория";
            sheetFirst.Cells[3, 1] = "Порода";
            sheetFirst.Cells[4, 1] = "Пол";
            sheetFirst.Cells[5, 1] = "Размер";
            sheetFirst.Cells[6, 1] = "Шерсть";
            sheetFirst.Cells[7, 1] = "Дата рождения";
            sheetFirst.Cells[8, 1] = "Дата регистрации";
            sheetFirst.Cells[9, 1] = "Номер паспорта";
            sheetFirst.Cells[10, 1] = "Имя владельца";

            sheetFirst.Cells[1, 2] = pet.Name;
            sheetFirst.Cells[2, 2] = pet.Category.Name;
            sheetFirst.Cells[3, 2] = pet.Breed;
            sheetFirst.Cells[4, 2] = pet.Gender.Name;
            sheetFirst.Cells[5, 2] = pet.Size.Name;
            sheetFirst.Cells[6, 2] = pet.Wool.Name;
            sheetFirst.Cells[7, 2] = pet.Birthday;
            sheetFirst.Cells[8, 2] = pet.DateRegistry;
            sheetFirst.Cells[9, 2] = "№" + pet.PassportNumber;
            sheetFirst.Cells[10, 2] = pet.OwnerName;

            sheetFirst.Cells.EntireColumn.AutoFit();
            sheetFirst.Cells.EntireRow.AutoFit();
            sheetFirst.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Worksheet sheetSecond = (Excel.Worksheet)excel.Worksheets.get_Item(2);
            sheetSecond.Name = "Вакцинация животного";

            sheetSecond.Cells[1, 1] = "Вакцина";
            sheetSecond.Cells[1, 2] = "Дата";

            var currentRowVaccination = 2;
            foreach (Vaccination vaccination in pet.Vaccinations.Values)
            {
                sheetSecond.Cells[currentRowVaccination, 1] = vaccination.Name;
                sheetSecond.Cells[currentRowVaccination, 2] = vaccination.Date;
                currentRowVaccination++;
            }

            sheetSecond.Cells.EntireColumn.AutoFit();
            sheetSecond.Cells.EntireRow.AutoFit();
            sheetSecond.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Worksheet sheetThird = (Excel.Worksheet)excel.Worksheets.get_Item(3);
            sheetThird.Name = "Вет. назнач. пройден.";

            sheetThird.Cells[1, 1] = "Описание";
            sheetThird.Cells[1, 2] = "Дата";
            sheetThird.Cells[1, 3] = "Имя файла";

            var currentRowVeterinaryActivity = 2;
            if (pet.VeterinaryActivities.ContainsKey(true))
            {
                foreach (VeterinaryActivity veterinaryActivity in pet.VeterinaryActivities[true].Values)
                {
                    sheetThird.Cells[currentRowVeterinaryActivity, 1] = veterinaryActivity.StandardVeterinaryActivity.Name;
                    sheetThird.Cells[currentRowVeterinaryActivity, 2] = veterinaryActivity.Date;
                    sheetThird.Cells[currentRowVeterinaryActivity, 3] = veterinaryActivity.DocumentOfVeterinaryActivityForPet.FilePath;
                    currentRowVeterinaryActivity++;
                }
            }

            sheetThird.Cells.EntireColumn.AutoFit();
            sheetThird.Cells.EntireRow.AutoFit();
            sheetThird.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Worksheet sheetFourth = (Excel.Worksheet)excel.Worksheets.get_Item(4);
            sheetFourth.Name = "Вет. назнач. текущ.";

            sheetFourth.Cells[1, 1] = "Описание";
            sheetFourth.Cells[1, 2] = "Дата";
            sheetFourth.Cells[1, 3] = "Имя файла";

            var currentRowVeterinaryActivityInFuture = 2;
            if (pet.VeterinaryActivities.ContainsKey(true))
            {
                foreach (VeterinaryActivity veterinaryActivity in pet.VeterinaryActivities[false].Values)
                {
                    sheetFourth.Cells[currentRowVeterinaryActivityInFuture, 1] = veterinaryActivity.StandardVeterinaryActivity.Name;
                    sheetFourth.Cells[currentRowVeterinaryActivityInFuture, 2] = veterinaryActivity.Date;
                    sheetFourth.Cells[currentRowVeterinaryActivityInFuture, 3] = veterinaryActivity.DocumentOfVeterinaryActivityForPet.FilePath;
                    currentRowVeterinaryActivityInFuture++;
                }
            }

            sheetFourth.Cells.EntireColumn.AutoFit();
            sheetFourth.Cells.EntireRow.AutoFit();
            sheetFourth.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


            Excel.Worksheet sheetFifth = (Excel.Worksheet)excel.Worksheets.get_Item(5);
            sheetFifth.Name = "Фото";

            sheetFifth.Cells[1, 1] = "Фото";

            var currentRowPhoto = 2;
            foreach (Photo photo in pet.Photos.Values)
            {
                var filePath = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 10, 10) + "Resources\\" + photo.FilePath + ".png";
                sheetFifth.Shapes.AddPicture(filePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 10, currentRowPhoto * 15 + 10, 50, 50);
                currentRowPhoto++;
            }

            sheetFifth.Cells.EntireColumn.AutoFit();
            sheetFifth.Cells.EntireRow.AutoFit();
            sheetFifth.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                excel.Application.ActiveWorkbook.SaveAs(sfd.FileName, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlShared,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excel.Application.ActiveWorkbook.Close();
                excel.Application.Quit();
            }
        }

        public void ExportWord(int id_pet)
        {
            Pet pet = new Pet(id_pet);

            Word.Application word = new Word.Application();

            try
            {
                var filePath = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 10, 10) + "Resources\\examplePetPassport.docx";
                var wordOpen = word.Documents.Open(filePath);

                String vaccinationRageDate = "";

                foreach (Vaccination vaccination in pet.Vaccinations.Values)
                {
                    if (vaccination.Name == "Против бешенства")
                    {
                        vaccinationRageDate = vaccination.Date.ToString("dd.MM.yyyy");
                    }
                }

                String ectoparasitesDate = "";
                String dewormingDate = "";

                if (pet.VeterinaryActivities.ContainsKey(true))
                {
                    foreach (VeterinaryActivity veterinaryActivity in pet.VeterinaryActivities[true].Values)
                    {
                        if (veterinaryActivity.StandardVeterinaryActivity.Name == "Обработка от эктопаразитов")
                        {
                            ectoparasitesDate = veterinaryActivity.Date.ToString("dd.MM.yyyy");
                        }
                        else if (veterinaryActivity.StandardVeterinaryActivity.Name == "Дегельминтизация")
                        {
                            dewormingDate = veterinaryActivity.Date.ToString("dd.MM.yyyy");
                        }
                    }
                }

                Dictionary<String, String> findToReplaceElements = new Dictionary<String, String>()
            {
                {"<nameOfOwnerPet>", pet.OwnerName.Split(' ')[1] },
                {"<secondNameOfOwnerPet>", pet.OwnerName.Split(' ')[0] },
                {"<categoryOfPet>", pet.Category.Name },
                {"<nameOfPet>", pet.Name },
                {"<breedOfPet>", pet.Breed },
                {"<genderOfPet>", pet.Gender.Name },
                {"<birthdayOfPet>", pet.Birthday.ToString("dd.MM.yyyy") },
                {"<vaccinationRageDate>", vaccinationRageDate },
                {"<numberOfPassport>", "№"+pet.PassportNumber },
                {"<registryDate>", pet.DateRegistry.ToString("dd.MM.yyyy") },
                {"<ectoparasitesDate>", ectoparasitesDate },
                {"<dewormingDate>", dewormingDate },
            };

                Word.Find find = word.Selection.Find;

                object missing = Type.Missing;



                object findTextStart = "<vaccinationSection>";
                Word.Range range = wordOpen.Content;

                range.Find.Execute(ref findTextStart, ref missing, ref missing, ref missing, ref
                  missing, ref missing, ref missing, ref missing, ref missing,
                  ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                var vaccinationSectionStart = range.Start;
                var vaccinationSectionEnd = range.End;

                range.Delete();

                if (pet.Vaccinations.Count > 0)
                {

                    Word.Application wordVaccination = new Word.Application();
                    var filePathToVaccinationSection = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 10, 10) + "Resources\\exampleVaccinationSection.docx";
                    var wordOpenVaccinationSection = wordVaccination.Documents.Open(filePathToVaccinationSection);

                    Word.Range rangeVaccination = wordOpenVaccinationSection.Content;

                    Word.Find findVaccination = rangeVaccination.Find;
                    var vaccinationDate = "<vaccinationDate>";
                    var vaccinationName = "<vaccinationName>";

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    foreach (Vaccination vaccination in pet.Vaccinations.Values)
                    {
                        if (vaccination.Name == "Против бешенства")
                        {
                            continue;
                        }
                        findVaccination.Text = vaccinationDate;
                        findVaccination.Replacement.Text = vaccination.Date.ToString("dd.MM.yyyy");

                        findVaccination.Execute(FindText: Type.Missing,
                            MatchCase: false,
                            MatchWholeWord: false,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing, Replace: replace);

                        findVaccination.Text = vaccinationName;
                        findVaccination.Replacement.Text = vaccination.Name;

                        findVaccination.Execute(FindText: Type.Missing,
                            MatchCase: false,
                            MatchWholeWord: false,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing, Replace: replace);

                        vaccinationDate = vaccination.Date.ToString("dd.MM.yyyy");
                        vaccinationName = vaccination.Name;

                        var currentRange = wordOpen.Range(vaccinationSectionStart, vaccinationSectionStart);

                        rangeVaccination.Copy();

                        Word.Range elementToVaccinationSection = wordOpen.Range(vaccinationSectionStart, vaccinationSectionStart);
                        elementToVaccinationSection.Paste();
                    }


                    wordVaccination.Application.ActiveDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                    wordVaccination.Application.Quit();
                }

                foreach (KeyValuePair<String, String> findElement in findToReplaceElements)
                {
                    find = word.Selection.Find;
                    find.Text = findElement.Key;
                    find.Replacement.Text = findElement.Value;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: Type.Missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: Word.WdFindWrap.wdFindContinue,
                        Format: false,
                        ReplaceWith: Type.Missing, Replace: Word.WdReplace.wdReplaceAll);
                }

                var filePathPhoto = "";
                foreach (Photo photo in pet.Photos.Values)
                {
                    filePathPhoto = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 10, 10) + "Resources\\" + photo.FilePath + ".png";
                    break;
                }
                object f = false;
                object t = true;
                object left = 10;
                object top = 20;
                object width = 70;
                object height = 70;
                object rangePhoto = Type.Missing;
                Microsoft.Office.Interop.Word.WdWrapType wrapPhoto = Microsoft.Office.Interop.Word.WdWrapType.wdWrapSquare;
                wordOpen.Shapes.AddPicture(filePathPhoto, ref f, ref t, ref left, ref top, ref width, ref height, ref rangePhoto).WrapFormat.Type = wrapPhoto;

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word files (*.docx)|*.docx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    word.Application.ActiveDocument.SaveAs2(sfd.FileName);
                    wordOpen.Application.ActiveDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                    word.Application.Quit();
                }
            }
            catch (Exception ex)
            {
                word.Application.ActiveDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
