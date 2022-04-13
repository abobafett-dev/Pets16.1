using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1
{
    public partial class cardOfPet : Form
    {
        public cardOfPet(int id_pet)
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            OpenPet(id_pet);
        }

        private void event_cardOfPet_Load(object sender, EventArgs e)
        {

        }

        private void OpenPet(int id_pet)
        {
            controller_cardOfPet controller_CardOfPet = new controller_cardOfPet();
            Pet currentPet = controller_CardOfPet.OpenPet(id_pet);
        }

        private void ExportToExcel()
        {

        }

        private void ExportToWord()
        {

        }

        private void event_Click_CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
