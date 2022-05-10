using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DGVWF;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1
{
    public partial class registryOfPets : Form
    {
        private Boolean PresentationType { get; set; }
        private int CurrentPage { get; set; }

        private Dictionary<string, dynamic> filtersAndSort = new Dictionary<string, dynamic>();

        private DataGridView currentDGVWF = new DataGridView();
        private List<Button> currentIconsOfPets = new List<Button>();

        public registryOfPets()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            PresentationType = false;
            CurrentPage = 1;
            OpenRegistry();

            var categories = new dbCategory().getAllCategories();
            foreach (var category in categories)
            {
                comboBox3.Items.Add(category.Value);
            }
        }

        private void event_registryOfPets_Load(object sender, EventArgs e)
        {

        }

        private void event_registryOfPets_Click_ChangePresentationType(object sender, EventArgs e)
        {
            ChangePresentationType();
            CurrentPage = 1;
            OpenRegistry();
        }

        private void ChangePresentationType()
        {
            PresentationType = !PresentationType;
        }

        private void OpenRegistry()
        {
            if (PresentationType == false)
            {
                tabPage1.Controls.Remove(currentDGVWF);
                foreach (var element in currentIconsOfPets)
                {
                    tabPage1.Controls.Remove(element);
                }
            }
            else if (PresentationType == true)
            {
                tabPage1.Controls.Remove(currentDGVWF);
                foreach (var element in currentIconsOfPets)
                {
                    tabPage1.Controls.Remove(element);
                }
            }
            currentIconsOfPets = new List<Button>();

            RegistryOfPetsController registryOfPets_controller = new RegistryOfPetsController();
            Dictionary<string, dynamic> infoAboutPets = registryOfPets_controller.OpenRegistry(CurrentPage, filtersAndSort);
            List<Pet> pets = infoAboutPets["pets"];

            CurrentPage = infoAboutPets["pageNumber"];
            label1.Text = CurrentPage.ToString();

            var currentPresentationType = PresentationType;

            if (currentPresentationType == false)
            {

                DataGridView newDGVWF = new DataGridView();

                newDGVWF.Bounds = new Rectangle(0, 0, 50, 50);
                newDGVWF.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
                newDGVWF.AllowUserToAddRows = false;
                newDGVWF.AllowUserToResizeColumns = false;
                newDGVWF.AllowUserToResizeRows = false;
                newDGVWF.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDGVWF.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                newDGVWF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                newDGVWF.Dock = DockStyle.Fill;
                newDGVWF.ReadOnly = true;

                newDGVWF.RowHeaderMouseClick += event_registryOfPets_DGVWF_RowHeaderMouseClick;

                tabPage1.Controls.Add(newDGVWF);
                currentDGVWF = newDGVWF;

                DataTable DT = new DataTable();

                DT.Columns.Add("id");
                DT.Columns.Add("Категория");
                DT.Columns.Add("Имя");
                DT.Columns.Add("Дата рождения", typeof(DateTime));
                DT.Columns.Add("Порода");
                DT.Columns.Add("Дата регистрации", typeof(DateTime));
                DT.Columns.Add("Номер паспорта");
                DT.Columns.Add("ФИО владельца");

                foreach(Pet pet in pets)
                {
                    DT.Rows.Add(pet.Id, pet.Category.Name, pet.Name, pet.Birthday, pet.Breed, pet.DateRegistry, "№"+pet.PassportNumber, pet.OwnerName);
                }

                DataSet DS = new DataSet();
                DS.Tables.Add(DT);

                newDGVWF.DataSource = DS.Tables[0];
                newDGVWF.Columns["id"].Visible = false;

                foreach (DataGridViewColumn column in newDGVWF.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            else if (currentPresentationType == true)
            {
                int locX = 50;
                int locY = 10;
                int currentElement = 1;

                foreach (Pet pet in pets)
                {
                    Button newButton = new Button();
                    newButton.Bounds = new Rectangle(locX, locY, 150, 160);
                    newButton.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
                    newButton.Name = "button_pet_" + pet.Id;
                    newButton.Text = pet.Name;
                    newButton.TextAlign = ContentAlignment.BottomCenter;



                    string firstPhotoFilePath = null;

                    if (pet.Photos.Count != 0)
                    {
                        firstPhotoFilePath = pet.Photos.First().Value.FilePath;
                    }

                    if(firstPhotoFilePath != null)
                    {
                        newButton.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(firstPhotoFilePath);
                    }

                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.Click += event_PetButton_Click;
                    newButton.MaximumSize = new System.Drawing.Size(150, 160);
                    tabPage1.Controls.Add(newButton);
                    currentIconsOfPets.Add(newButton);
                    if (currentElement % 4 == 0)
                    {
                        locX = 50;
                        locY += 170;
                    }
                    else
                    {
                        locX += 160;
                    }

                    currentElement++;
                }

                tabPage1.AutoScrollMinSize = new System.Drawing.Size(0,locY + 170);
            }
        }

        private void OpenPet(int id_pet)
        {
            Form form = new cardOfPet(id_pet);
            form.Show();
        }

        private void ExportToExcel()
        {
            filtersAndSort = new Dictionary<string, dynamic>();
            if (comboBox3.SelectedItem != null)
            {
                filtersAndSort.Add("category", comboBox3.SelectedItem.ToString());
            }

            filtersAndSort.Add("breed", textBox1.Text);
            filtersAndSort.Add("petName", textBox2.Text);
            filtersAndSort.Add("passportNumber", textBox6.Text);
            filtersAndSort.Add("ownerName", textBox7.Text);

            if (checkBox1.Checked)
            {
                filtersAndSort.Add("birthdayFrom", dateTimePicker1.Value);
                filtersAndSort.Add("birthdayTo", dateTimePicker2.Value);
            }

            if (checkBox2.Checked)
            {
                filtersAndSort.Add("dateRegistryFrom", dateTimePicker4.Value);
                filtersAndSort.Add("dateRegistryTo", dateTimePicker3.Value);
            }

            if (comboBox1.SelectedItem != null)
            {
                filtersAndSort.Add("sortColumn", comboBox1.SelectedItem.ToString());
            }

            if (comboBox2.SelectedItem != null)
            {
                filtersAndSort.Add("sortType", comboBox2.SelectedItem.ToString());
            }

            RegistryOfPetsController registryOfPetsController = new RegistryOfPetsController();
            registryOfPetsController.ExportExcel(filtersAndSort);
        }

        private void event_CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        private void event_ExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void event_PetButton_Click(object sender, EventArgs e)
        {
            var id_pet = int.Parse((sender as Button).Name.Split('_')[2]);
            OpenPet(id_pet);
        }

        private void event_registryOfPets_DGVWF_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id_pet = int.Parse((String)(this.currentDGVWF.Rows[e.RowIndex].Cells[0].Value));
            OpenPet(id_pet);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            OpenRegistry();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            OpenRegistry();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filtersAndSort = new Dictionary<string, dynamic>();
            if (comboBox3.SelectedItem != null)
            {
                filtersAndSort.Add("category", comboBox3.SelectedItem.ToString());
            }

            filtersAndSort.Add("breed", textBox1.Text);
            filtersAndSort.Add("petName", textBox2.Text);
            filtersAndSort.Add("passportNumber", textBox6.Text);
            filtersAndSort.Add("ownerName", textBox7.Text);

            if (checkBox1.Checked)
            {
                filtersAndSort.Add("birthdayFrom", dateTimePicker1.Value);
                filtersAndSort.Add("birthdayTo", dateTimePicker2.Value);
            }

            if (checkBox2.Checked)
            {
                filtersAndSort.Add("dateRegistryFrom", dateTimePicker4.Value);
                filtersAndSort.Add("dateRegistryTo", dateTimePicker3.Value);
            }

            if (comboBox1.SelectedItem != null)
            {
                filtersAndSort.Add("sortColumn", comboBox1.SelectedItem.ToString());
            }

            if (comboBox2.SelectedItem != null)
            {
                filtersAndSort.Add("sortType", comboBox2.SelectedItem.ToString());
            }

            CurrentPage = 1;
            OpenRegistry();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filtersAndSort = new Dictionary<string, dynamic>();

            CurrentPage = 1;
            OpenRegistry();
        }
    }
}
