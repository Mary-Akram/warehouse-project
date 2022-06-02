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
    public partial class ExpPert : Form
    {
        Test2Entities db;
        public ExpPert()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            this.Hide();
            frm.Show();
        }

        private void ExpPert_Load(object sender, EventArgs e)
        {
            foreach (Store st in db.Stores)
            {
                comboBox1.Items.Add(st.St_Name);
            }
            foreach (var sup in db.Clients)
            {
                comboBox2.Items.Add(sup.Cl_Email);
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

        private void button1_Click(object sender, EventArgs e)
        {
            PerExport pi = new PerExport();
            ExpQuantity ex = new ExpQuantity();
            
            if (textBox1.Text!=""||comboBox1.Text != "" || comboBox2.Text != "" ||comboBox3.Text != ""||textBox6.Text!=""||textBox7.Text!="")
            {
                Store str = db.Stores.Find(comboBox1.Text);
                Product pro = db.Products.Find(int.Parse(comboBox3.Text));
                Client cl = db.Clients.Find(comboBox2.Text);

                if (str != null && pro != null && cl != null) //There is a store
                {

                    var AvailableWorker = db.PerExports.Find(int.Parse(textBox1.Text));
                    ex = db.ExpQuantities.Find(int.Parse(textBox6.Text));

                    if (AvailableWorker == null & ex == null)
                    {
                        //pi.Per_Num = int.Parse(textBox1.Text);
                        //pi.Per_Date = dateTimePicker1.Value;
                        //pi.St_Name = comboBox1.Text;
                        //textBox2.Text = pi.St_Name;
                        //pi.P_Code = int.Parse(comboBox3.Text);
                        //textBox4.Text = pi.P_Code.ToString();
                        //pi.Cl_Email = comboBox2.Text;
                        //textBox3.Text = pi.Cl_Email;
                        //textBox5.Text = cl.Cl_Name;
                        //db.PerExports.Add(pi);
                        db.perEx(int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, dateTimePicker1.Value);
                      
                        db.Insrexq(int.Parse(textBox6.Text), int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, int.Parse(textBox7.Text));
                  

                        db.SaveChanges();

                       
                        MessageBox.Show("تم الحفظ");
                        textBox6.Text = textBox7.Text =comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text =string.Empty;


                    }
                    else
                    {
                        MessageBox.Show("Can't Add Existing Data");
                    }
                }
            }

            else
            {
                MessageBox.Show("please add all data");
            }

            }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" || comboBox1.Text != "" || comboBox2.Text != "" || comboBox3.Text != "" || textBox6.Text != "" || textBox7.Text != "")
            {
                try
                {
                    // int Id = int.Parse(comboBox4.Text);
                    //PerExport pi = db.PerExports.Find(Id);
                    // pi.Per_Num = int.Parse(textBox1.Text);
                    // pi.Per_Date = dateTimePicker1.Value;
                    // pi.St_Name = comboBox1.Text;
                    //  textBox2.Text=pi.St_Name;

                    // pi.P_Code = int.Parse(comboBox3.Text);
                    // textBox4.Text = pi.P_Code.ToString();
                    // pi.Cl_Email = comboBox2.Text;

                    // textBox3.Text = pi.Cl_Email;
                    db.upExPer(int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, dateTimePicker1.Value);
                    db.upQUExp3(int.Parse(textBox6.Text), int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, int.Parse(textBox7.Text));
                }
                catch (FormatException)
                {
                    MessageBox.Show("please add correct Format");
                }

                db.SaveChanges();
                textBox6.Text = textBox7.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("please add all data");

            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerExport pi = new PerExport();
            var Id = int.Parse(comboBox4.Text);
            pi = db.PerExports.Find(Id);

            textBox1.Text = pi.Per_Num.ToString();

            dateTimePicker1.Value = pi.Per_Date.Value;
            comboBox2.Text = pi.Cl_Email;
         


            comboBox1.Text = pi.St_Name;
            comboBox3.Text = pi.P_Code.ToString();
          


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || comboBox1.Text != "" || comboBox2.Text != "" || comboBox3.Text != "" || textBox6.Text != "" || textBox7.Text != "")
            {
                try
                {

                    int ID = int.Parse(textBox1.Text);
                    var pro = db.PerExports.Find(ID);

                    foreach (var pr in db.ExpQuantities)
                    {
                        if (pr.Per_Num == ID && pr.ExpId == int.Parse(textBox6.Text))
                        {
                            db.ExpQuantities.Remove(pr);
                        }
                    }
                    db.PerExports.Remove(pro);
                    db.SaveChanges();
                    MessageBox.Show("تم حذف البيانات");
                    textBox6.Text = textBox7.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = textBox1.Text = string.Empty;
                }
                catch (Exception)
                {
                    MessageBox.Show("sorry dear but there is one of this mistake :you  added the same email , you added toooooooooooooo long number or,you added inncroocet format");

                }
            }
            else
            {
                MessageBox.Show("please add all data");

            }
        }


    private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.disolayPerExp().ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //var result = db.disolayPerExp().SingleOrDefault(x => x.Per_Num == id);
            //textBox6.Text = result.ExpId.ToString();
            //textBox7.Text = result.Out_Quantity.ToString();
            //comboBox1.Text = result.St_Name;
            //comboBox2.Text = result.Cl_Email;
            //comboBox3.Text = result.P_Code.ToString();
            //textBox1.Text = result.Per_Num.ToString();
            //dateTimePicker1.Value = result.Per_Date.Value;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.disolayPerExp().SingleOrDefault(x => x.Per_Num == id);
                textBox6.Text = result.ExpId.ToString();
                textBox7.Text = result.Out_Quantity.ToString();
                comboBox1.Text = result.St_Name;
                comboBox2.Text = result.Cl_Email;
                comboBox3.Text = result.P_Code.ToString();
                textBox1.Text = result.Per_Num.ToString();
                dateTimePicker1.Value = result.Per_Date.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("sorry dear but there is one of this mistake :you  added the same email , you added toooooooooooooo long number or,you added inncroocet format");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExportPermisionReport frm = new ExportPermisionReport();
            this.Hide();
            frm.Show();
        }
    }
    }



