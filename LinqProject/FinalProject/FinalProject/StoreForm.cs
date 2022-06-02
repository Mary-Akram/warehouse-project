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
    public partial class StoreForm : Form
    {
        Test2Entities db;
        public StoreForm()
        {
            InitializeComponent();
            db = new Test2Entities();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var st = db.Stores.Find(textBox1.Text);
            if (st == null)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("برجاء ادخال كل البيانات");
                }
                else
                {
                    Store str = new Store();
                    str.St_Name = textBox1.Text;
                    str.St_Adress = textBox2.Text;
                    str.St_Manger = textBox3.Text;
                    Test2Entities db = new Test2Entities();
                    db.Stores.Add(str);
                    db.SaveChanges();
                    MessageBox.Show("تم حفظ البيانات");
                    textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                }

            }
            else
            {
                MessageBox.Show("أسم الفرع متاح بالفعل");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            dataGridView1.DataSource = db.Stores.ToList();
            comboBox1.Items.Clear();
            var stor = from st in db.Stores select st;
            foreach (var str in stor)
            {
                //listBox1.Items.Add(str.St_Name+ "   " + str.St_Adress+"   "+str.St_Manger);
                comboBox1.Items.Add(str.St_Name);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Name = comboBox1.Text;
            var stor = (from st in db.Stores
                        where st.St_Name == Name
                        select st).First();
            if (stor != null)
            {
               textBox1.Text = stor.St_Name;
                textBox2.Text = stor.St_Adress;

                textBox3.Text = stor.St_Manger;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = textBox1.Text;
                var str = (from st in db.Stores
                           where st.St_Name == Name
                           select st).First();

                if (Name != null)
                {

                    str.St_Manger = textBox3.Text;
                    str.St_Adress = textBox2.Text;
                    db.SaveChanges();
                    MessageBox.Show("Data is Changed");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("you  did something wrong");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = textBox1.Text;
                var str = (from st in db.Stores
                           where st.St_Name == Name
                           select st).First();
                if (Name != null)
                {
                    db.Stores.Remove(str);
                    db.SaveChanges();
                    MessageBox.Show("store Deleted");
                    textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                    comboBox1.Items.Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("you  did something wrong");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var result = db.Stores.SingleOrDefault(x => x.St_Name ==Name);
            textBox1.Text = result.St_Name;
            textBox3.Text = result.St_Manger;
            textBox2.Text = result.St_Adress;
        
        }
    }
    }

