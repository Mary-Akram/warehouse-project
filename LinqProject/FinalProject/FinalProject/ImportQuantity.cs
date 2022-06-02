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
    public partial class ImportQuantity : Form

    {
        Test2Entities db;
        public ImportQuantity()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ImportQuantity_Load(object sender, EventArgs e)
        {
            foreach (Store st in db.Stores)
            {
                comboBox4.Items.Add(st.St_Name);
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
            dataGridView1.DataSource = db.ImpQuantities.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("برجاء ادخال كل البيانات");
            }
            else
            {
                ImpQuantity imp = db.ImpQuantities.Find(int.Parse(textBox1.Text));
                if (imp==null)
                {
                    ImpQuantity Iq = new ImpQuantity();
                    Iq.St_Name = comboBox1.Text;
                    Iq.Sup_Email = comboBox2.Text;
                    Iq.P_Code = int.Parse(comboBox3.Text);
                    //Iq.Per_Num = int.Parse(comboBox4.Text);
                    Iq.ImpId = int.Parse(textBox1.Text);
                    Iq.In_Quantity = int.Parse(textBox3.Text);
                    Iq.Transform_Date = dateTimePicker1.Value;
                    Iq.New_Store = comboBox4.Text;
                    db.aftertrans(int.Parse(textBox3.Text), comboBox1.Text, int.Parse(comboBox3.Text));
                    db.ImpQuantities.Add(Iq);
                    
                    db.SaveChanges();
                    MessageBox.Show("تم حفظ البيانات");
                    comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text  = textBox3.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("This data is avalible");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("برجاء ادخال كل البيانات");
            }
            else
            {
                int Code = int.Parse(textBox1.Text);
                var Iq = (from Imp in db.ImpQuantities
                          where Imp.ImpId == Code
                          select Imp).First();

                Iq.St_Name = comboBox1.Text;
                Iq.Sup_Email = comboBox2.Text;
                Iq.P_Code = int.Parse(comboBox3.Text);
                Iq.New_Store = comboBox4.Text;
                Iq.ImpId = int.Parse(textBox1.Text);
                Iq.In_Quantity = int.Parse(textBox3.Text);
                Iq.Transform_Date = dateTimePicker1.Value;
                db.SaveChanges();
                MessageBox.Show("Data Changed");
                comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text = textBox3.Text = string.Empty;
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.ImpQuantities.SingleOrDefault(x => x.ImpId== id);
            textBox1.Text = result.ImpId.ToString();
            textBox3.Text = result.In_Quantity.ToString();
            comboBox1.Text = result.St_Name;
            comboBox2.Text = result.Sup_Email;
            comboBox3.Text = result.P_Code.ToString();
            comboBox4.Text = result.New_Store;
            dateTimePicker1.Value = result.Transform_Date.Value;
//comboBox4.Text = result.Per_Num.ToString();
             

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("برجاء ادخال كل البيانات");
            }
            else
            {

                int Code = int.Parse(textBox1.Text);
                var Iq = (from Imp in db.ImpQuantities
                          where Imp.ImpId == Code
                          select Imp).First();
                if (Iq != null)
                {
                    db.ImpQuantities.Remove(Iq);
                    db.SaveChanges();
                    MessageBox.Show("Deleted");

                    comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text = textBox3.Text = string.Empty;

                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Pco = db.chosecode(int.Parse(comboBox3.Text));
            foreach (var p in Pco)
            {
                comboBox1.Items.Add(p);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Ret3().ToList();
        }
    }
}
