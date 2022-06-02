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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProdForm frm = new ProdForm();

            this.Hide();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StoreForm frm = new StoreForm();

            this.Hide();
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClForm frm = new ClForm();

            this.Hide();
            frm.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SupRep frm = new SupRep();

            this.Hide();
            frm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            ExpPert frm = new ExpPert();

            this.Hide();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ImportQuantity frm = new ImportQuantity();

            this.Hide();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExpQu frm = new ExpQu();

            this.Hide();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           ImportPermisiion frm = new ImportPermisiion();

            this.Hide();
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
          ImportQuantity frm = new ImportQuantity();

            this.Hide();
            frm.Show();

        }

        private void تقريرعنالاصنافالتيقاربتعلىانتهاءالصلاحيةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تقريرعنالاصنافالتيقاربتعلىانتهاءالصلاحيةToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            this.Hide();
            frm.Show();
        }

        private void تقريرعنالاصنافالتيمرعليهافترةزمنيةفيالمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Repo2 frm = new Repo2();

            this.Hide();
            frm.Show();

        }

        private void تقريرعنكلصنفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report3 frm = new Report3();

            this.Hide();
            frm.Show();
        }

        private void storeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goToReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Transformcs frm = new Transformcs();

            this.Hide();
            frm.Show();
        }

        private void تقريرعنحركةالاصناففيفترهمعينهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerImp frm = new PerImp();
            this.Hide();
            frm.Show();
        }
    }
    }
    
