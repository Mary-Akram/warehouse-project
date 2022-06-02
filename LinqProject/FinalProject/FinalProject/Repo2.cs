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
    public partial class Repo2 : Form
    {
        Test2Entities db;

        public Repo2()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void Repo2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'test2DataSet1.diffDate' table. You can move, or remove it, as needed.
            dataGridView1.DataSource = db.diffDate3().ToList();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = db.Report2(dateTimePicker2.Value).ToList();
            dataGridView1.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.diffDate3().ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
