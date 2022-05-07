using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new registryOfPets();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new registryOfMissingPetsAnnouncements();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new OlennikovForm2();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dbGender = new dbGender();
            var elements = dbGender.getAllGenders();
            foreach(var id in elements.Keys)
            {
                foreach(var element_id in elements[id].Keys)
                {
                    MessageBox.Show(elements[id][element_id].ToString());
                }
            }
        }
    }
}
