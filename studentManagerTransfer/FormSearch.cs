using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentManagerTransfer
{
    public partial class frmSearch : Form
    {
         StudentBLL bllST;

        public frmSearch()
        {
            InitializeComponent();
            bllST = new StudentBLL();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            ShowAllStudent();

            timer1.Start();
            lblTimee.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        public void ShowAllStudent()
        {
            DataTable dt = bllST.getAllStudent();
            dataGridViewStudent.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string value = txtSearch.Text.Trim();

            if (!String.IsNullOrEmpty(value))
            {
                DataTable dt = bllST.FindStudent(value);
                dataGridViewStudent.DataSource = dt;

            }
            else
            {
                ShowAllStudent();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimee.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
