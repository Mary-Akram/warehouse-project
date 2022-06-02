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
    public partial class Transformcs : Form
    {
        Test2Entities db;
        public Transformcs()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void Transformcs_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.Stores.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Stores.Where(x => x.St_Name.Contains(textBox3.Text)).ToList();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Stores.ToList();

        }
    }
}
