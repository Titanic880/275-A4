using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotData.Components
{
    /// <summary>
    /// Used to Check if the database exists
    /// </summary>
    public class DBChecker
    {
        //Create either a timer or a background worker to check every 1-5 seconds
        //a method from here is called if the background worker in DBFileManip returns false
        
        public DBChecker()
        {

        }


        /// <summary>
        /// Checks what form of the database to use
        /// </summary>
        /// <returns></returns>
        public static bool CheckDataBaseType()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tests the Sql Connection
        /// </summary>
        internal static bool Test_Conn()
        {
            string Table_Loggging = "Create Table Test_conn (" +
                 "ID int not null Primary key Identity(0,1)," +
                 "LogLevel int not null," +
                 "Error_Desc varchar(50)," +
                 "Time_Of_Error DateTime not null" +
                 ");";
            string check_tbl = "Select * from Test_conn";

            bool test = true;

            try
            {
                sql.Open();

                //Tests to see if the table exists, if it doesn't the runs the Table create
                try
                {
                    SqlCommand comm = new SqlCommand(check_tbl, sql);
                    comm.ExecuteScalar();
                }
                catch
                {
                    test = false;
                }
                if (!test)
                {
                    SqlCommand cmd = new SqlCommand(Table_Loggging, sql);
                    cmd.ExecuteScalar();
                }
                SqlCommand drop = new SqlCommand("Drop Table Test_conn;", sql);
                drop.ExecuteScalar();
                test = true;
            }
            catch
            {
                test = false;
            }
            finally
            {
                if (sql.State != ConnectionState.Closed)
                    sql.Close();
            }

            return test;
        }




    }
}
