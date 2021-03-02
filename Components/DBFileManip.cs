using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        BackgroundWorker wkr = new BackgroundWorker();
        private SqlConnection conn;
        public bool Completed { get; private set; } = false;

        public DBFileManip()
        {
            //checks to see if the db has already been assigned
            if (DBChecker.ConnectionType == -1)
                DBChecker.SetDatabaseType();

            //Initilizes the connection
            conn = new SqlConnection(DataInfo.connections[DBChecker.ConnectionType]);

            if (!DBChecker.CheckTableExist("Data"))
                CreateDataTable();

            //Sets up the worker
            wkr.DoWork += Wkr_DoWork;
            wkr.RunWorkerCompleted += Wkr_RunWorkerCompleted;
            wkr.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Main Work of the worker is done here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            //just checking to see if theres something int the queue
            while (!wkr.CancellationPending)
            {
                if(DBChecker.Connected() && DataInfo.ToDatabaseQ.Count != 0)
                {
                    //popping the first item off the database
                    string str = DataInfo.ToDatabaseQ.Dequeue().GetInformation();
                    //Inserts to Database -- if false then it adds it to the Queue for the File system
                    if (InsertData(str))
                        DataInfo.OverflowQ.Enqueue(new DataSchema(str));
                }
            }
            //todo
        }

        /// <summary>
        /// Runs when the worker has completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Completed = true;
        }

        public bool InsertData(string DeviceName)
        {
            //Splits the input
            string[] Values = DeviceName.Split(',');

            //Builds the Query
            string query = $@"
                Insert into Data values (
                    '{Values[0]}',
                    '{Values[1]}',
                    '{Values[2]}',
                    '{Values[3]}',
                    '{Values[4]}', 
                    '{Values[5]}',
                    '{Values[6]}'
                    )";
            SqlCommand cmd = new SqlCommand(query, conn);
            
            //Runs the Query -- If the insert fails it returns false
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }


        /// <summary>
        /// Starts the worker that deals with the Database
        /// </summary>
        public void StartFileWorker()
        {
            wkr.RunWorkerAsync();
        }

        public void StopFileWorker()
        {
            wkr.CancelAsync();
        }

        /// <summary>
        /// A test method for checking the database
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllFromDatabase(string TableName = "Data")
        {
            DataTable ret = new DataTable();
            SqlCommand cmd = new SqlCommand($"Select * From {TableName}", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ret);
            return ret;
        }
        //bool createscheema = true;

        private void CreateDataTable()
        {
            string createTableQuery = @"
                  CREATE TABLE [dbo].[Data](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DeviceName] [nvarchar](50) NOT NULL,
	[DeviceType] [nvarchar](50) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[UnitOfMeasure1] [nvarchar](50) NOT NULL,
	[UnitOfMeasureValue1] [decimal](18, 0) NULL,
	[UnitOfMeasure2] [nvarchar](50) NOT NULL,
	[UnitOFMeasureValue2] [decimal](18, 0) NULL
	);
                ";
            
            /*
            CREATE TABLE 275Assign5DB.dbo.Data
                  (
                      Name varchar(50) NOT NULL,
                      Phone varchar(11) NOT NULL,
                      Email varchar(50) NOT NULL,
                      Picture varbinary(MAX) NOT NULL,
                      Message varchar(250) NOT NULL,
                      SignDatetime datetime NOT NULL
                   )*/
            SqlCommand cmd = new SqlCommand(createTableQuery, conn);

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                
            }
            finally
            {
                if(conn.State != ConnectionState.Closed)
                conn.Close();
            }
        }
    }
}
