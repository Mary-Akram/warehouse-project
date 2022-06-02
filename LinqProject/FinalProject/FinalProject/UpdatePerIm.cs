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
    public partial class UpdatePerIm : Form
    {
        Test2Entities db;
        public UpdatePerIm()
        {
            InitializeComponent();
            db = new Test2Entities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         try
            {

                var result1 = db.upPer(int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, dateTimePicker1.Value, int.Parse(textBox2.Text));
                // var resul2 = db.up3(int.Parse(textBox2.Text), int.Parse(textBox1.Text), int.Parse(comboBox3.Text), comboBox2.Text, comboBox1.Text, int.Parse(textBox3.Text));


                db.SaveChanges();
                dataGridView1.DataSource = db.PerImports.ToList();


            }

            catch (Exception ) { MessageBox.Show("Your data won't upn date due to error"); }
            this.Hide();
            ImportPermisiion frm = new ImportPermisiion();
              frm.Show();
           
          
                


            textBox1.Text = comboBox1.Text = comboBox2.Text =comboBox3.Text = textBox2.Text = string.Empty;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //var result = db.upPer2().SingleOrDefault(x => x.PerNum == id);
            //textBox3.Text = result.ImpId.ToString();
            //textBox2.Text = result.In_Quantity.ToString();
            //comboBox1.Text = result.St_Name;
            //comboBox2.Text = result.Sup_Email;
            //comboBox3.Text = result.P_Code.ToString();
            //textBox1.Text = result.PerNum.ToString();
            //dateTimePicker1.Value = result.PerDate.Value;
        }

        private void UpdatePerIm_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.PerImports.ToList();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.PerImports.SingleOrDefault(x => x.PerNum == id);
           
            textBox2.Text = result.Quentity.ToString();
            comboBox1.Text = result.St_Name;
            comboBox2.Text = result.Sup_Email;
            comboBox3.Text = result.P_Code.ToString();
            textBox1.Text = result.PerNum.ToString();
            dateTimePicker1.Value = result.PerDate.Value;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(textBox1.Text);
                var pro = db.PerImports.Find(ID);


                db.PerImports.Remove(pro);
                db.SaveChanges();
            }catch(Exception)
            {
                MessageBox.Show("do u forget to put your dataaa");
            }
            //MessageBox.Show("تم حذف البيانات");
            textBox1.Text = comboBox1.Text = comboBox2.Text =comboBox3.Text = textBox2.Text  = string.Empty;
                }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ImportPermisiion frm = new ImportPermisiion();
            this.Hide();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
