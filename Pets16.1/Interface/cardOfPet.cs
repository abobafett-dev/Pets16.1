using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NesterovForm3 : Form
    {
        public NesterovForm3()
        {
            int id_pet = 1;
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            OpenPet(id_pet);
        }

        private void NesterovForm3_Load(object sender, EventArgs e)
        {

        }

        private void OpenPet(int id)
        {

        }

        private void ExportToExcel()
        {

        }

        private void ExportToWord()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
