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
    public partial class ExpQu : Form
    {
        Test2Entities db;
        public ExpQu()
        {
            InitializeComponent();
            db = new Test2Entities();

        }

  
            private void button1_Click(object sender, EventArgs e)
            {
                if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
                {
                    MessageBox.Show("برجاء ادخال كل البيانات");
                }
                else
                {
                     ExpQuantity imp = db.ExpQuantities.Find(int.Parse(textBox1.Text));
                    if (imp == null)
                    {
                     ExpQuantity Iq = new ExpQuantity();
                        Iq.St_Name = comboBox1.Text;
                        Iq.Cl_Email = comboBox2.Text;
                        Iq.P_Code = int.Parse(comboBox3.Text);
                        Iq.Per_Num = int.Parse(comboBox4.Text);
                        Iq.ExpId = int.Parse(textBox1.Text);
                        Iq.Out_Quantity = int.Parse(textBox3.Text);
                        db.ExpQuantities.Add(Iq);
                        db.SaveChanges();
                        MessageBox.Show("تم حفظ البيانات");
                        comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text = textBox3.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("This data is avalible");
                    }

                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                int Code = int.Parse(textBox1.Text);
                var Iq = (from Exp in db.ExpQuantities
                          where Exp.ExpId == Code
                          select Exp).First();

                Iq.St_Name = comboBox1.Text;
                Iq.Cl_Email = comboBox2.Text;
                Iq.P_Code = int.Parse(comboBox3.Text);
                Iq.Per_Num = int.Parse(comboBox4.Text);
                Iq.ExpId = int.Parse(textBox1.Text);
                Iq.Out_Quantity= int.Parse(textBox3.Text);
                db.SaveChanges();
                MessageBox.Show("Data Changed");
                comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text = textBox3.Text = string.Empty;

            }

            private void dataGridView1_SelectionChanged(object sender, EventArgs e)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.ExpQuantities.SingleOrDefault(x => x.ExpId == id);
            try
            {
                textBox1.Text = result.ExpId.ToString();
                textBox3.Text = result.Out_Quantity.ToString();
                comboBox1.Text = result.St_Name;
                comboBox2.Text = result.Cl_Email;
                comboBox3.Text = result.P_Code.ToString();
                comboBox4.Text = result.Per_Num.ToString();
              }
            catch
            {

            }


            }

            private void button3_Click(object sender, EventArgs e)
            {
                int Code = int.Parse(textBox1.Text);
                var Iq = (from Imp in db.ExpQuantities
                          where Imp.ExpId == Code
                          select Imp).First();
                if (Iq != null)
                {
                    db.ExpQuantities.Remove(Iq);
                    db.SaveChanges();
                    MessageBox.Show("Deleted");

                    comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text  = textBox3.Text = string.Empty;

                }

            }

        private void ExpQu_Load(object sender, EventArgs e)
        {
            foreach (Store st in db.Stores)
            {
                comboBox1.Items.Add(st.St_Name);
            }
            foreach (var cl in db.Clients)
            {
                comboBox2.Items.Add(cl.Cl_Email);
            }
            foreach (var Pro in db.Products)
            {
                comboBox3.Items.Add(Pro.P_Code);
            }

            foreach (PerExport pi in db.PerExports)
            {
                comboBox4.Items.Add(pi.Per_Num);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ExpQuantities.ToList();

        }

     
    }
    }


    

