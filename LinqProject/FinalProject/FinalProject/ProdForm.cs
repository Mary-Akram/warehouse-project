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
    public partial class ProdForm : Form
    {
        Test2Entities db;
        int id;
        public ProdForm()
        {
            InitializeComponent();
            db = new Test2Entities();
            textBox5.Visible = false;



        }


        private void button1_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            PrMeasure Me = new PrMeasure();
            if (prod != null && Me != null) //There is a store
            {
                try
                {

                    var Id = db.Products.Find(int.Parse(textBox1.Text));
                    if (Id == null)
                    {

                        if (textBox1.Text == "" || textBox2.Text == "")
                        {
                            MessageBox.Show("برجاء ادخال كل البيانات");
                        }
                        else
                        {

                            prod.P_Code = int.Parse(textBox1.Text);
                            prod.P_Name = textBox2.Text;
                            prod.P_Date = dateTimePicker1.Value;
                            prod.Exp_Date = dateTimePicker2.Value;
                            Me.P_Code = int.Parse(textBox1.Text);

                            Me.Measure = textBox4.Text;
                            db.Products.Add(prod);
                            db.PrMeasures.Add(Me);

                            db.SaveChanges();
                            MessageBox.Show("تم حفظ البيانات");


                            textBox1.Text = textBox2.Text = textBox4.Text = string.Empty;
                        }
                    }
            
           
                else
                {
                    MessageBox.Show("This data is avalible");
                    textBox1.Text = textBox2.Text = textBox4.Text = string.Empty;
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("you  did something wrong");
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                textBox5.Enabled = true;
                PrMeasure Me = new PrMeasure();
                int Code = int.Parse(textBox1.Text);
                var dept = (from pd in db.Products
                            where pd.P_Code == Code
                            select pd).First();
                Me = db.PrMeasures.Find((int.Parse(textBox1.Text)), textBox5.Text);

                if (dept != null && Me != null) //There is a store
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("برجاء ادخال كل البيانات");
                    }
                    else
                    {

                        //dept.P_Name = textBox2.Text;
                        //dept.P_Date = dateTimePicker1.Value;
                        //dept.Exp_Date = dateTimePicker2.Value;
                        //Me.P_Code = dept.P_Code;

                        //Me.Measure = textBox5.Text;



                        db.UpDateProduct(int.Parse(textBox1.Text), textBox2.Text, dateTimePicker1.Value, dateTimePicker2.Value);
                        db.UpDateMeasure(int.Parse(textBox1.Text), textBox4.Text);
                        dept.P_Code = int.Parse(textBox1.Text);
                        Me.P_Code = dept.P_Code;


                        db.SaveChanges();
                        MessageBox.Show("Data is Changed");
                        textBox1.Text = textBox2.Text = textBox4.Text = string.Empty;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("you  did something wrong");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.proMeaser().Where(x => x.P_Name.Contains(textBox3.Text)).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.proMeaser().ToList();
            ;

        }


   



        private void ProdForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'test2DataSet.PrMeasure' table. You can move, or remove it, as needed.
            //this.prMeasureTableAdapter.Fill(this.test2DataSet.PrMeasure);
            //var Me = from Mea in db.PrMeasures select Mea.P_Code;
            //foreach(var Mr in Me)
            //{
            //    comboBox1.Items.Add(Mr);
            //}

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void ProdForm_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int ID = int.Parse(textBox1.Text);
            Product pro = db.Products.Find(ID);

            foreach (PrMeasure pr in db.PrMeasures)
            {
                if (pr.P_Code == ID && pr.Measure == textBox5.Text)
                {
                    db.PrMeasures.Remove(pr);
                }
            }
            db.Products.Remove(pro);
            db.SaveChanges();
            MessageBox.Show("تم حذف البيانات");
            textBox1.Text = textBox2.Text = textBox4.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("you  did something wrong");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.proMeaser().SingleOrDefault(x => x.P_Code == id);
            textBox1.Text = result.P_Code.ToString();
            textBox2.Text = result.P_Name;
            dateTimePicker1.Value = result.P_Date;
            dateTimePicker2.Value = result.Exp_Date;
            textBox5.Text = result.Measure.ToString();
            textBox4.Text = textBox5.Text;



        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

