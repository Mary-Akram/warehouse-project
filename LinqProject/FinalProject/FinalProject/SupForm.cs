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
    public partial class SupForm : Form
    {

        Test2Entities db;
        public SupForm()
        {
            InitializeComponent();
            db = new Test2Entities();
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
                cl.Sup_Name = textBox1.Text;
                cl.Sup_Mobile = int.Parse(textBox2.Text);
                cl.Sup_phone = int.Parse(textBox3.Text);
                cl.Sup_Email = textBox4.Text;
                cl.Sup_Fax = textBox5.Text;
                cl.Sup_Site = textBox6.Text;

                Test2Entities db = new Test2Entities();
                db.Suppliers.Add(cl);
                db.SaveChanges();
                MessageBox.Show("تم حفظ البيانات");
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
                string mail = textBox4.Text;
            var email = (from cl in db.Suppliers
                         where cl.Sup_Email == mail
                         select cl).First();
                if (email != null)
                {
                    email.Sup_Name= textBox1.Text;
                    email.Sup_Mobile = int.Parse(textBox2.Text);
                    email.Sup_phone = int.Parse(textBox3.Text);
                    email.Sup_Fax = textBox5.Text;
                    email.Sup_Site = textBox6.Text;
                    db.SaveChanges();
                    comboBox1.Items.Add(email.Sup_Email);
                    MessageBox.Show("Data is Changed");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {

                MessageBox.Show("برجاء ادخال كل البيانات");
            }
            else { 
                string mail = textBox4.Text;

            var email = (from cl in db.Suppliers
                         where cl.Sup_Email == mail
                         select cl).First();
            if (email != null)
            {
                db.Suppliers.Remove(email);
                db.SaveChanges();
                MessageBox.Show("Client Deleted");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;

            }
        }
        }



      

       
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.Suppliers.ToList();

        }

       
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string mail = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    var result = db.Suppliers.SingleOrDefault(x => x.Sup_Email == mail);
        //    textBox1.Text = result.Sup_Name;
        //    textBox4.Text = result.Sup_Email;

        //    textBox2.Text = result.Sup_Mobile.ToString();
        //    textBox3.Text = result.Sup_phone.ToString();
        //    textBox5.Text = result.Sup_Fax;
        //    textBox6.Text = result.Sup_Site;
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mail = db.Suppliers.Find(comboBox1.Text);
            if (mail != null)
            {
                textBox1.Text = mail.Sup_Name;
                textBox4.Text = mail.Sup_Email;

                textBox2.Text = mail.Sup_Mobile.ToString();
                textBox3.Text = mail.Sup_phone.ToString();
                textBox5.Text = mail.Sup_Fax;
                textBox6.Text = mail.Sup_Site;
            }
        }

        private void SupForm_Load(object sender, EventArgs e)
        {
            foreach (var sup in db.Suppliers)
            {
                comboBox1.Items.Add(sup.Sup_Email);
            }
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string mail = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    var result = db.Suppliers.SingleOrDefault(x => x.Sup_Email == mail);
        //    textBox1.Text = result.Sup_Name;
        //    textBox4.Text = result.Sup_Email;

        //    textBox2.Text = result.Sup_Mobile.ToString();
        //    textBox3.Text = result.Sup_phone.ToString();
        //    textBox5.Text = result.Sup_Fax;
        //    textBox6.Text = result.Sup_Site;
        //}

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SupRep frm = new SupRep();
           frm.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string mail = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //var result = db.Suppliers.SingleOrDefault(x => x.Sup_Email == mail);
            //textBox1.Text = result.Sup_Name;
            //textBox4.Text = result.Sup_Email;

            //textBox2.Text = result.Sup_Mobile.ToString();
            //textBox3.Text = result.Sup_phone.ToString();
            //textBox5.Text = result.Sup_Fax;
            //textBox6.Text = result.Sup_Site;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mail = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            var result = db.Suppliers.SingleOrDefault(x => x.Sup_Email == mail);
            textBox1.Text = result.Sup_Name;
            textBox4.Text = result.Sup_Email;

            textBox2.Text = result.Sup_Mobile.ToString();
            textBox3.Text = result.Sup_phone.ToString();
            textBox5.Text = result.Sup_Fax;
            textBox6.Text = result.Sup_Site;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }

}
