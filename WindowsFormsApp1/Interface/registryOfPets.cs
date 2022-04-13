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

namespace WindowsFormsApp1
{
    public partial class NesterovForm2 : Form
    {
        private Boolean presentationType;

        public void SetPresentationType(Boolean value) 
        {
            presentationType = value;
        }

        public Boolean GetPresentationType()
        {
            return presentationType;
        }

        public NesterovForm2()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            OpenRegistry();
        }

        private void ChangePresentationType()
        {
            SetPresentationType(!GetPresentationType());
        }

        private void OpenRegistry()
        {
            DataGridViewWithFilter DG = new DataGridViewWithFilter();
            DG.Bounds = new Rectangle(15, 35, 744, 428);
            DG.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right | AnchorStyles.Bottom)));
            DG.AllowUserToAddRows = false;

            DG.RowHeaderMouseClick += DT_RowHeaderMouseClick;

            this.Controls.Add(DG);

            DataTable DT = new DataTable();

            DT.Columns.Add("Категория");
            DT.Columns.Add("Имя");
            DT.Columns.Add("Дата рождения", typeof(DateTime));
            DT.Columns.Add("Порода");
            DT.Columns.Add("Дата регистрации", typeof(DateTime));
            DT.Columns.Add("Номер паспорта");
            DT.Columns.Add("ФИО владельца");
            DT.Rows.Add("Собака", "Пёс", "14.02.1995", "Лысый", "13.04.2022", "№32140123894", "Иванов Иван Иванович");
            DT.Rows.Add("Кошка", "Кот", "14.02.1991", "Арбалет", "13.04.2022", "№32140233894", "Иванов Иван Иванович");

            DataSet DS = new DataSet();
            DS.Tables.Add(DT);

            DG.DataSource = DS.Tables[0];
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NesterovForm2_Load(object sender, EventArgs e)
        {

        }

        private void DT_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form form = new NesterovForm3();
            form.Show();
        }
    }
}
