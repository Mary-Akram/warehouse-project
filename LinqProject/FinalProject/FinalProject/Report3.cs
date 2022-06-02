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

    public partial class Report3 : Form
    {
        Test2Entities db;

        public Report3()
        {
            InitializeComponent();
            db = new Test2Entities();
          

        }

        private void Rep3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Rep3().ToList();
            foreach (var Pro in db.Products)
            {
                comboBox1.Items.Add(Pro.P_Name);
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.RepChose(comboBox1.Text).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Rep3().ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
