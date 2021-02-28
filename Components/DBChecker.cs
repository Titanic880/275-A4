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
    /// Used to Check if the database exists
    /// </summary>
    public class DBChecker
    {
        //Create either a timer or a background worker to check every 1-5 seconds
        //a method from here is called if the background worker in DBFileManip returns false
        
        public DBChecker()
        {
            //SqlConnection conn = new SqlConnection(connectionString);
        }

        private static string LabString = ConfigurationManager.ConnectionStrings["labString"].ConnectionString;
        private static string DockString = ConfigurationManager.ConnectionStrings["DockerStr"].ConnectionString;
        SqlConnection conn;
        //0 = Uninitilized, 1 = Windows Verf(Lab), 2=Docker
        public static int ConnectionType = 0;


        /// <summary>
        /// Checks what form of the database to use
        /// </summary>
        /// <returns></returns>
        public static int CheckDataBaseType()
        {
            if (Test_Conn(LabString))
                return ConnectionType = 1;
            else if (Test_Conn(DockString))
                return ConnectionType = 2;
            else
                return ConnectionType = 0;
        }

        /// <summary>
        /// Tests the Sql Connection
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <returns></returns>
        internal static bool Test_Conn(string connectionstring)
        {
            return Test_Conn(new SqlConnection(connectionstring));
        }

        /// <summary>
        /// Tests the Sql Connection
        /// </summary>
        /// 
        // mitch i changed this from static to not static cusits thowing errors with it static
        internal static bool Test_Conn(SqlConnection connection)
        {
            //Checks for the connection string
            if (connection.ConnectionString == null)
                return false;

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
                connection.Open();

                //Tests to see if the table exists, if it doesn't the runs the Table create
                try
                {
                    SqlCommand comm = new SqlCommand(check_tbl, connection);
                    comm.ExecuteNonQuery();
                }
                catch
                {
                    test = false;
                }
                if (!test)
                {
                    SqlCommand cmd = new SqlCommand(Table_Loggging, connection);
                    cmd.ExecuteNonQuery();
                }
                SqlCommand drop = new SqlCommand("Drop Table Test_conn;", connection);
                drop.ExecuteNonQuery();
                test = true;
            }
            catch
            {
                test = false;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            return test;
        }




    }
}
