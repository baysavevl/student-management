using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagerTransfer
{
    class StudentDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public StudentDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllStudent()
        {
            //command sql

            string sql = "SELECT * FROM tblStudent";

            // create a connect
            SqlConnection con = dc.getConnect();

            //init an object 
            da = new SqlDataAdapter(sql, con);

            //open the connect
            con.Open();

            //implement data from dataAdapter to Datatable
            DataTable dt = new DataTable();
            da.Fill(dt);

            //close the connect
            con.Close();
            return dt;
        }

        public bool InsertStudent(tblStudent st)
        {
            string sql = "INSERT INTO tblStudent(studentID, studentName, studentClass, studentScore) VALUES(@studentID, @studentName, @studentClass, @studentScore)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@studentID", SqlDbType.NVarChar).Value = st.studentId;
                cmd.Parameters.Add("@studentName", SqlDbType.NVarChar).Value = st.studentName;
                cmd.Parameters.Add("@studentClass", SqlDbType.NVarChar).Value = st.studentClass;
                cmd.Parameters.Add("@studentScore", SqlDbType.NVarChar).Value = st.studentScore;

                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception e)
            {
                return false;
            }
            return true;


        }

        public bool UpdateStudent(tblStudent st)
        {
            string sql = "UPDATE tblStudent SET  studentName = @studentName, studentClass = @studentClass, studentScore = @studentScore WHERE studentId = @studentId";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@studentID", SqlDbType.NVarChar).Value = st.studentId;
                cmd.Parameters.Add("@studentName", SqlDbType.NVarChar).Value = st.studentName;
                cmd.Parameters.Add("@studentClass", SqlDbType.NVarChar).Value = st.studentClass;
                cmd.Parameters.Add("@studentScore", SqlDbType.NVarChar).Value = st.studentScore;

                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public bool DeleteStudent(tblStudent st)
        {
            string sql = "DELETE tblStudent WHERE studentId = @studentId";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@studentID", SqlDbType.NVarChar).Value = st.studentId;

                
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable FindStudent(String st)
        {
            string sql = "SELECT * FROM tblStudent WHERE studentName like '%" +st+ "%' OR studentClass like '% " +st+ "%' ";

            // create a connect
            SqlConnection con = dc.getConnect();

            //init an object 
            da = new SqlDataAdapter(sql, con);

            //open the connect
            con.Open();

            //implement data from dataAdapter to Datatable
            DataTable dt = new DataTable();
            da.Fill(dt);

            //close the connect
            con.Close();

            return dt;
        }



    }
}
