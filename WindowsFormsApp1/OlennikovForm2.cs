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
    public partial class OlennikovForm2 : Form
    {
        public OlennikovForm2()
        {
            InitializeComponent();
        }

        private void OlennikovForm2_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form form = new OlennikovForm3();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form form = new OlennikovForm3();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new OlennikovForm4();
            form.Show();
        }

        private void Применить_Click(object sender, EventArgs e)
        {

        }
    }
}
