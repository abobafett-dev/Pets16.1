using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVWF;
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1
{
    public partial class registryOfPets : Form
    {
        private Boolean PresentationType { get; set; }

        private DataGridViewWithFilter currentDGVWF = new DataGridViewWithFilter();
        private List<Button> currentIconsOfPets = new List<Button>();

        public registryOfPets()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            PresentationType = false;
            OpenRegistry();
        }

        private void event_registryOfPets_Load(object sender, EventArgs e)
        {

        }

        private void event_registryOfPets_Click_ChangePresentationType(object sender, EventArgs e)
        {
            if(PresentationType == false)
            {
                this.Controls.Remove(currentDGVWF);
            }
            else if(PresentationType == true)
            {
                foreach(var element in currentIconsOfPets)
                {
                    this.Controls.Remove(element);
                }
            }
            currentIconsOfPets = new List<Button>();
            ChangePresentationType();
            OpenRegistry();
        }

        private void ChangePresentationType()
        {
            PresentationType = !PresentationType;
        }

        private void OpenRegistry()
        {
            registryOfPets_controller registryOfPets_controller = new registryOfPets_controller();
            List<Pet> pets = registryOfPets_controller.OpenRegistry();

            var currentPresentationType = PresentationType;

            if (currentPresentationType == false)
            {
                this.AutoScrollMinSize = new System.Drawing.Size(0, 500);

                DataGridViewWithFilter newDGVWF = new DataGridViewWithFilter();

                newDGVWF.Bounds = new Rectangle(15, 35, 744, 428);
                newDGVWF.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
                newDGVWF.AllowUserToAddRows = false;
                newDGVWF.AllowUserToResizeColumns = false;
                newDGVWF.AllowUserToResizeRows = false;
                newDGVWF.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                newDGVWF.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                newDGVWF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                newDGVWF.RowHeaderMouseClick += event_registryOfPets_DGVWF_RowHeaderMouseClick;

                this.Controls.Add(newDGVWF);
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
                
                ///TODO: Убрать временные данные, после подключения БД
                DT.Rows.Add(1, "собака", "пёс", new DateTime(1995,04,13), "лысый", new DateTime(2022, 04, 13), "№32140123894", "Иванов Иван Иванович");
                DT.Rows.Add(2, "кошка", "кот", new DateTime(1991, 04, 13), "арбалет", new DateTime(2022, 04, 13), "№32140233894", "Иванов Иван Иванович");
                ///

                DataSet DS = new DataSet();
                DS.Tables.Add(DT);

                newDGVWF.DataSource = DS.Tables[0];
                newDGVWF.Columns["id"].Visible = false;
            }
            else if (currentPresentationType == true)
            {
                //int sizeForm = 784;
                //button
                //button_id
                //text 
                //textAlign = BottomCenter
                //backgroundimage
                //backgroundimagelayout = zoom
                //width = 150
                //height = 160
                //start location
                // x = 10
                // y = 40
                int locX = 10;
                int locY = 40;
                int currentElement = 1;

                foreach (Pet pet in pets)
                {
                    Button newButton = new Button();
                    newButton.Bounds = new Rectangle(locX, locY, 150, 160);
                    newButton.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
                    newButton.Name = "button_pet_" + pet.Id;
                    newButton.Text = pet.Name;
                    newButton.TextAlign = ContentAlignment.BottomCenter;
                    newButton.BackgroundImage = Properties.Resources.exampleImage;
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.Click += event_PetButton_Click;
                    newButton.MaximumSize = new System.Drawing.Size(150, 160);
                    this.Controls.Add(newButton);
                    currentIconsOfPets.Add(newButton);
                    if (currentElement % 4 == 0)
                    {
                        locX = 10;
                        locY += 170;
                    }
                    else
                    {
                        locX += 160;
                    }

                    ///TODO: Убрать временные данные, после подключения БД
                    currentElement++;
                    ///
                }

                ///TODO: Убрать временные данные, после подключения БД
                for (var i = currentElement; i < 20; i++)
                {
                    Button newButton = new Button();
                    newButton.Bounds = new Rectangle(locX, locY, 150, 160);
                    newButton.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
                    newButton.Name = "button_pet_"+i;
                    newButton.Text = "кличка животного "+i;
                    newButton.TextAlign = ContentAlignment.BottomCenter;
                    newButton.BackgroundImage = Properties.Resources.exampleImage;
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.Click += event_PetButton_Click;
                    newButton.MaximumSize = new System.Drawing.Size(150,160);
                    this.Controls.Add(newButton);
                    currentIconsOfPets.Add(newButton);
                    if (i % 4 == 0)
                    {
                        locX = 10;
                        locY += 170;
                    }
                    else
                    {
                        locX += 160;
                    }
                }
                ///

                this.AutoScrollMinSize = new System.Drawing.Size(0,locY + 170);
            }
        }

        private void OpenPet(int id_pet)
        {
            Form form = new cardOfPet(id_pet);
            form.Show();
        }

        private void ExportToExcel()
        {

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
    }
}
