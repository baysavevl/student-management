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
    public partial class frmEdit : Form
    {

        public String temp1, temp2, temp3, temp4;

        public frmEdit()
        {
            InitializeComponent();
        }

        private void fromEdit_Load(object sender, EventArgs e)
        {
            txtID.Text = temp1;
            txtID.ReadOnly = true;

            txtName.Text = temp2;
            txtClass.Text = temp3;
            txtScore.Text = temp4;

            timer1.Start();
            lblTimee.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();


            this.Hide();


        }

        //chuyen may text thi them chung do Text
        public delegate void GETDATAedit(string data, string data2, string data3, string data4);

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimee.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        public GETDATAedit myData;





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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                myData(this.txtID.Text, this.txtName.Text, this.txtClass.Text, this.txtScore.Text);
                this.Hide();
            }
        }
    }
}
