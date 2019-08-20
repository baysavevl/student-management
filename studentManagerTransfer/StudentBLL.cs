using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagerTransfer
{
    class StudentBLL
    {
        StudentDAL dalST;


        public StudentBLL()
        {
            dalST = new StudentDAL();
        }

        public DataTable getAllStudent()
        {
            return dalST.getAllStudent();
        }

        public bool InsertStudent(tblStudent st)
        {
            return dalST.InsertStudent(st);

        }

        public bool UpdateStudent(tblStudent st)
        {
            return dalST.UpdateStudent(st);
        }

        public bool DeleteStudent(tblStudent st)
        {
            return dalST.DeleteStudent(st);
        }

        public DataTable FindStudent(String st)
        {
            return dalST.FindStudent(st);
        }
    }
}