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
    public partial class SupRep : Form
    {
        Test2Entities db;
        public SupRep()
        {
            InitializeComponent();
         db = new Test2Entities();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mail = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var result = db.Suppliers.SingleOrDefault(x => x.Sup_Email == mail);
            textBox1.Text = result.Sup_Name;
            textBox4.Text = result.Sup_Email;

            textBox2.Text = result.Sup_Mobile.ToString();
            textBox3.Text = result.Sup_phone.ToString();
            textBox5.Text = result.Sup_Fax;
            textBox6.Text = result.Sup_Site;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.Suppliers.ToList();
            MessageBox.Show("press on grade");
        }

        private void SupRep_Load(object sender, EventArgs e)
        {
            //foreach (var sup in db.Suppliers)
            //{
            //    comboBox1.Items.Add(sup.Sup_Email);
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {

                MessageBox.Show("برجاء ادخال كل البيانات");
            }
            else
            {
                Supplier cl = new Supplier();
                try
                {

                    cl.Sup_Name = textBox1.Text;
                    cl.Sup_Mobile = int.Parse(textBox2.Text);
                    cl.Sup_phone = int.Parse(textBox3.Text);
                    cl.Sup_Email = textBox4.Text;
                    cl.Sup_Fax = textBox5.Text;
                    cl.Sup_Site = textBox6.Text;

                    Test2Entities db = new Test2Entities();
                    db.Suppliers.Add(cl);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("sorry dear but there is one of this mistake :you  added the same email , you added toooooooooooooo long number or,you added inncroocet format");
                }
                MessageBox.Show("If the data is correct we will save it please do refersh to check");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {

                MessageBox.Show("برجاء ادخال كل البيانات");
            }
            else
            {
                try
                {
                    string mail = textBox4.Text;
                var email = (from cl in db.Suppliers
                             where cl.Sup_Email == mail
                             select cl).First();
                    if (email != null)
                    {
                        email.Sup_Name = textBox1.Text;
                        email.Sup_Mobile = int.Parse(textBox2.Text);
                        email.Sup_phone = int.Parse(textBox3.Text);
                        email.Sup_Fax = textBox5.Text;
                        email.Sup_Site = textBox6.Text;
                        db.SaveChanges();
                        //comboBox1.Items.Add(email.Sup_Email);
                        MessageBox.Show("Data is Changed");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("sorry dear but there is one of this mistake :you  added the same email , you added toooooooooooooo long number or,you added inncroocet format");

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {

                MessageBox.Show("برجاء ادخال كل البيانات");
            }
            else
            {
                try
                {
                    string mail = textBox4.Text;

                    var email = (from cl in db.Suppliers
                                 where cl.Sup_Email == mail
                                 select cl).First();
                    if (email != null)
                    {
                        db.Suppliers.Remove(email);
                        db.SaveChanges();
                        MessageBox.Show("supplier  Deleted");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("sorry dear but there is one of this mistake :you  added the same email , you added toooooooooooooo long number or,you added inncroocet format");

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
    }

