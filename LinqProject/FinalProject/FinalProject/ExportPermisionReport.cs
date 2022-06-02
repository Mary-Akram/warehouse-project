using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class ExportPermisionReport : Form
    {
        Test2Entities db;
        public ExportPermisionReport()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void ImpoPerQuentity2_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource= db.Export().ToList();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpPert frm = new ExpPert();
            this.Hide();
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
