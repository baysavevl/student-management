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
    public partial class frmMain : Form
    {
        StudentBLL bllST;

        public frmMain()
        {
            InitializeComponent();
            bllST = new StudentBLL();
            
            
            
        }

        private void frmMain_Load(object sender, EventArgs e)
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


        public void GETVALUEadd(string v1, string v2, string v3, string v4)
        {
            txtID.Text = v1;
            txtName.Text = v2;
            txtClass.Text = v3;
            txtScore.Text = v4;

            tblStudent st = new tblStudent();

            st.studentId = txtID.Text.Trim();
            st.studentName = txtName.Text.Trim();
            st.studentClass = txtClass.Text.Trim();
            st.studentScore = txtScore.Text.Trim();

            if (bllST.InsertStudent(st))
            {
                ShowAllStudent();
            }

        }

        public void GETVALUEedit(string v1, string v2, string v3, string v4)
        {
            txtID.Text = v1;
            txtName.Text = v2;
            txtClass.Text = v3;
            txtScore.Text = v4;

            tblStudent st = new tblStudent();

            st.studentId = ID;
            st.studentName = txtName.Text.Trim();
            st.studentClass = txtClass.Text.Trim();
            st.studentScore = txtScore.Text.Trim();

            if (bllST.UpdateStudent(st))
            {
                ShowAllStudent();
            }

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd form = new frmAdd();
            form.myData = new frmAdd.GETDATAadd(GETVALUEadd);
            form.Show();

        }


       
        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please choose a student to Edit", "Notice", MessageBoxButtons.YesNo);
            }
            else
            {

                frmEdit form = new frmEdit();

                form.temp1 = txtID.Text.Trim();
                form.temp2 = txtName.Text.Trim();
                form.temp3 = txtClass.Text.Trim();
                form.temp4 = txtScore.Text.Trim();


                form.myData = new frmEdit.GETDATAedit(GETVALUEedit);
                form.Show();

            }
        }

        string ID;
        private void dataGridViewStudent_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = txtID.Text = dataGridViewStudent.Rows[index].Cells[0].Value.ToString().Trim();
                txtName.Text = dataGridViewStudent.Rows[index].Cells[1].Value.ToString().Trim();
                txtClass.Text = dataGridViewStudent.Rows[index].Cells[2].Value.ToString().Trim();
                txtScore.Text = dataGridViewStudent.Rows[index].Cells[3].Value.ToString().Trim();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this student?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblStudent st = new tblStudent();

                st.studentId = ID;

                if(bllST.DeleteStudent(st))
            {
                    ShowAllStudent();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo);

            if (DialogResult.Yes == dialog)
            {
                Application.Exit();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimee.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch form = new frmSearch();
            form.Show();
        }
    }
}
