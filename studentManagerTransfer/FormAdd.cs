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
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            this.Hide();

            timer1.Start();
            lblTimee.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        //chuyen may text thi them chung do Text
        public delegate void GETDATAadd(string data, string data2, string data3, string data4);
        public GETDATAadd myData;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                myData(this.txtID.Text, this.txtName.Text, this.txtClass.Text, this.txtScore.Text);
                this.Hide();
            }
        }




        public bool checkData()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please input student ID", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please input student Name", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtClass.Text))
            {
                MessageBox.Show("Please input student Class", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtClass.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtScore.Text))
            {
                MessageBox.Show("Please input student Score", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtScore.Focus();
                return false;
            }
            return true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimee.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
