using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagerTransfer
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source =VinhL\\SQLEXPRESS; Initial Catalog = studentMananger; Integrated Security = true;  ";

        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }

    }
}
