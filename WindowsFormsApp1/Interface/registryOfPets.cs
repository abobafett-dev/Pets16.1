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
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1
{
    public partial class registryOfPets : Form
    {
        private Boolean PresentationType { get; set; }

        private DataGridViewWithFilter currentDGVWF = new DataGridViewWithFilter();
        private List<Button> currentPets = new List<Button>();

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
                foreach(var element in currentPets)
                {
                    this.Controls.Remove(element);
                }
            }
            currentPets = new List<Button>();
            ChangePresentationType();
            OpenRegistry();
        }

        private void ChangePresentationType()
        {
            PresentationType = !PresentationType;
        }

        private void OpenRegistry()
        {
            var currentPresentationType = PresentationType;
            List<Pet> pets = new List<Pet>();

            if (currentPresentationType == false)
            {
                this.AutoScrollMinSize = new System.Drawing.Size(0, 500);
                currentDGVWF.Bounds = new Rectangle(15, 35, 744, 428);
                currentDGVWF.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
                currentDGVWF.AllowUserToAddRows = false;

                currentDGVWF.RowHeaderMouseClick += event_registryOfPets_DGVWF_RowHeaderMouseClick;

                this.Controls.Add(currentDGVWF);

                DataTable DT = new DataTable();

                DT.Columns.Add("id");
                DT.Columns.Add("Категория");
                DT.Columns.Add("Имя");
                DT.Columns.Add("Дата рождения", typeof(DateTime));
                DT.Columns.Add("Порода");
                DT.Columns.Add("Дата регистрации", typeof(DateTime));
                DT.Columns.Add("Номер паспорта");
                DT.Columns.Add("ФИО владельца");

                DT.Rows.Add(1, "Собака", "Пёс", new DateTime(1995,04,13), "Лысый", new DateTime(2022, 04, 13), "№32140123894", "Иванов Иван Иванович");
                DT.Rows.Add(2, "Кошка", "Кот", new DateTime(1991, 04, 13), "Арбалет", new DateTime(2022, 04, 13), "№32140233894", "Иванов Иван Иванович");

                DataSet DS = new DataSet();
                DS.Tables.Add(DT);

                currentDGVWF.DataSource = DS.Tables[0];
                currentDGVWF.Columns["id"].Visible = false;
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
                for (var i = 1; i < 20; i++)
                {
                    Button newButton = new Button();
                    newButton.Bounds = new Rectangle(locX, locY, 150, 160);
                    newButton.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
                    newButton.Name = "button_pet_"+i;
                    newButton.Text = "кличка животного "+i;
                    newButton.TextAlign = ContentAlignment.BottomCenter;
                    newButton.BackgroundImage = Properties.Resources.image_12;
                    newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    newButton.Click += event_PetButton_Click;
                    newButton.MaximumSize = new System.Drawing.Size(150,160);
                    this.Controls.Add(newButton);
                    currentPets.Add(newButton);
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
                this.AutoScrollMinSize = new System.Drawing.Size(0,locY + 170);
            }
        }

        private void event_PetButton_Click(object sender, EventArgs e)
        {
            var id_pet = int.Parse((sender as Button).Name.Split('_')[2]);
            OpenPet(id_pet);
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

        private void event_registryOfPets_DGVWF_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id_pet = (int)(this.currentDGVWF.Rows[e.RowIndex].Cells[0].Value);
            OpenPet(id_pet);
        }

        private void event_ExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
