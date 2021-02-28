using System.Data;
using System.Data.SqlClient;

namespace IotData.Components
{
    /// <summary>
    /// Used to Check if the database exists
    /// </summary>
    public static class DBChecker
    {
        private readonly static SqlConnection conn;
        /// <summary>
        /// 0 = Uninitilized, 1 = Windows Verf(Lab), 2=Docker
        /// </summary>
        public static int ConnectionType { get; private set; } = -1;

        /// <summary>
        /// Checks what form of the database to use
        /// </summary>
        /// <returns></returns>
        public static int SetDatabaseType()
        {
            if (Test_Conn(DataInfo.connections[0]))
                return ConnectionType = 0;
            else if (Test_Conn(DataInfo.connections[1]))
                return ConnectionType = 1;
            else
                return ConnectionType = -1;
        }

        /// <summary>
        /// Checks if the given table exists, ALWAYS USE AFTER SETTING DB
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        public static bool CheckTableExist(string Table)
        {
            return Test_Conn(conn, Table);
        }

        /// <summary>
        /// Returns true if database exists
        /// </summary>
        /// <returns></returns>
        public static bool Connected()
        {
            if (ConnectionType != -1)
                return Test_Conn(DataInfo.connections[ConnectionType]);
            else
            {
                ConnectionType = -1;
                return false;
            }

        }
        /// <summary>
        /// Tests the Sql Connection
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <returns></returns>
        private static bool Test_Conn(string connectionstring)
        {
            return Test_Conn(new SqlConnection(connectionstring));
        }

        /// <summary>
        /// Tests the Sql Connection
        /// </summary>
        ///
        private static bool Test_Conn(SqlConnection connection)
        {
            //Checks for the connection string
            if (connection.ConnectionString == null)
                return false;

            string Table_Loggging = "Create Table TEST_CONN (" +
                 "ID int not null Primary key Identity(0,1)," +
                 "LogLevel int not null," +
                 "Error_Desc varchar(50)," +
                 "Time_Of_Error DateTime not null" +
                 ");";
            string check_tbl = "Select * from TEST_CONN";

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
        private static bool Test_Conn(SqlConnection connection, string TableName)
        {
            //Checks for the connection string
            if (connection.ConnectionString == null)
                return false;

            string check_tbl = $"Select * from {TableName}";

            bool test = true;

            try
            {
                connection.Open();
                //Tests to see if the table exists, if it doesn't the runs the Table create
                try
                {
                    SqlCommand comm = new SqlCommand(check_tbl, connection);
                    comm.ExecuteNonQuery();
                    test = true;
                }
                catch
                {
                    test = false;
                }
                //END OF SECOND TRY/CATCH
            }
            //END OF FIRST TRY/CATCH
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

