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
    public partial class PerImp : Form
    {
        Test2Entities db;
        public PerImp()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void PerImp_Load(object sender, EventArgs e)
        {
            foreach (Store st in db.Stores)
            {
                comboBox1.Items.Add(st.St_Name);
            }

            
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = db.Trans1(comboBox1.Text, dateTimePicker1.Value, dateTimePicker3.Value).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("empty info");


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Movment().ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }

      
    }




