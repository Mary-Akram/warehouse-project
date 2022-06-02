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
    public partial class Form2 : Form
    {
        Test2Entities db;
        
        public Form2()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.diffDate3().ToList();
           

          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = db.diffDate2(int.Parse(textBox1.Text)).ToList();
            }
            catch (Exception){ }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.diffDate3().ToList();
        }
    }
}
