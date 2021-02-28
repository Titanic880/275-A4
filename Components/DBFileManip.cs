using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotData.Components
{
    /// <summary>
    /// Houses the background worker and methods that have to do with the Database
    /// </summary>
    public class DBFileManip
    {

        private SqlConnection conn;


        public DBFileManip()
        {
            if(DBChecker.ConnectionType == -1)
                DBChecker.SetDatabaseType();
        }

        public void startfileworker()
        {
            //bgw.RunWorkerAsync();
        }

        /// <summary>
        /// A test method for checking the database
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllFromDatabase(string TableName = "Data")
        {
            DataTable ret = new DataTable();
            SqlConnection conn = new SqlConnection(DataInfo.connections[0]);
            SqlCommand cmd = new SqlCommand($"Select * From {TableName}", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ret);
            return ret;
        }
    }
}
