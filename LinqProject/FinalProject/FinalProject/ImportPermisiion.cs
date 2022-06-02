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
    public partial class ImportPermisiion : Form
    {
        Test2Entities db;
       
        public ImportPermisiion()
        {
            InitializeComponent();
            db = new Test2Entities();

        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void ImportPermisiion_Load(object sender, EventArgs e)
        {



            foreach (Store st in db.Stores)
            {
                comboBox1.Items.Add(st.St_Name);
            }
            foreach (var sup in db.Suppliers)
            {
                comboBox2.Items.Add(sup.Sup_Email);
            }
            foreach (var Pro in db.Products)
            {
                comboBox3.Items.Add(Pro.P_Code);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Perview().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  PerImport pi = new PerImport();
             //ImpQuantity ex = new ImpQuantity();
            if (textBox1.Text != "" || comboBox1.Text != "" || comboBox2.Text != "" || comboBox3.Text != "" || textBox3.Text != "")
            {


                var AvailableWorker = db.PerImports.Find(int.Parse(textBox1.Text));
                //ex = db.ImpQuantities.Find(int.Parse(textBox2.Text));

                if (AvailableWorker == null )
                {
                    try
                    {

                        db.InsrPer(int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, dateTimePicker1.Value, int.Parse(textBox3.Text));
                       //db.InsrImq(int.Parse(textBox2.Text), int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, int.Parse(textBox3.Text));
                        db.SaveChanges();
                        MessageBox.Show("your  data is saved");
                        textBox1.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = textBox3.Text = string.Empty;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error here");
                    }


                }
                else
                {
                    MessageBox.Show("your data is avalible");
                }
            }
            
            else
            {
                MessageBox.Show("you need to put all data");
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdatePerIm frm = new UpdatePerIm();
            this.Hide();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}