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
    public partial class ClForm : Form
    {
        Test2Entities db;
        public ClForm()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            var mail = db.Clients.Find(textBox4.Text);
            if (mail == null)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {

                    MessageBox.Show("برجاء ادخال كل البيانات");
                }
                else
                {
                    try
                    {
                        Client cl = new Client();
                        cl.Cl_Name = textBox1.Text;
                        cl.Cl_Mobile = int.Parse(textBox2.Text);
                        cl.Cl_Phone = int.Parse(textBox3.Text);
                        cl.Cl_Email = textBox4.Text;
                        cl.Cl_Fax = textBox5.Text;
                        cl.Cl_Site = textBox6.Text;

                        Test2Entities db = new Test2Entities();
                        db.Clients.Add(cl);
                        db.SaveChanges();
                        MessageBox.Show("تم حفظ البيانات");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("you did something wrong");
                    }

                }
            }
            else
            {
                MessageBox.Show("This client is avalible");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {

                    MessageBox.Show("برجاء ادخال كل البيانات");
                }
            else {
                try { 
            string mail = textBox4.Text;
            var email = (from cl in db.Clients
                         where cl.Cl_Email == mail
                         select cl).First();
                    if (email != null)
                    {
                        email.Cl_Name = textBox1.Text;
                        email.Cl_Mobile = int.Parse(textBox2.Text);
                        email.Cl_Phone = int.Parse(textBox3.Text);
                        email.Cl_Fax = textBox5.Text;
                        email.Cl_Site = textBox6.Text;
                        db.SaveChanges();
                        MessageBox.Show("Data is Changed");

                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;

                  
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("you did something wrong");
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

                    var email = (from cl in db.Clients
                                 where cl.Cl_Email == mail
                                 select cl).First();
                    if (email != null)
                    {
                        db.Clients.Remove(email);
                        db.SaveChanges();
                        MessageBox.Show("Client Deleted");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("you did something wrong");
                }
            }
          
        }

       

        

   
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("press on email");
          dataGridView1.DataSource = db.Clients.ToList();

        }

    

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //string mail = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //var result = db.Clients.SingleOrDefault(x => x.Cl_Email == mail);


        //textBox1.Text = result.Cl_Name;
        //        textBox4.Text = result.Cl_Email;

        //       textBox2.Text = result.Cl_Mobile.ToString();
        //        textBox3.Text = result.Cl_Phone.ToString();
        //        textBox5.Text = result.Cl_Fax;
        //        textBox6.Text = result.Cl_Site;
       
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mail = db.Clients.Find(comboBox1.Text);
            if (mail != null)
            {
                textBox1.Text = mail.Cl_Name;
                textBox4.Text = mail.Cl_Email;

                textBox2.Text = mail.Cl_Mobile.ToString();
                textBox3.Text = mail.Cl_Phone.ToString();
                textBox5.Text = mail.Cl_Fax;
                textBox6.Text = mail.Cl_Site;
            }
        }

        private void ClForm_Load(object sender, EventArgs e)
        {
            foreach (var sup in db.Clients)
            {
                comboBox1.Items.Add(sup.Cl_Email);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mail = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var result = db.Clients.SingleOrDefault(x => x.Cl_Email == mail);


            textBox1.Text = result.Cl_Name;
            textBox4.Text = result.Cl_Email;

            textBox2.Text = result.Cl_Mobile.ToString();
            textBox3.Text = result.Cl_Phone.ToString();
            textBox5.Text = result.Cl_Fax;
            textBox6.Text = result.Cl_Site;
        }
    }

}