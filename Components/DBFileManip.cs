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


        public DBFileManip()
        {
            //checks to see if the db has already been assigned
            if (DBChecker.ConnectionType == -1)
                DBChecker.SetDatabaseType();

            //Initilizes the connection
            conn = new SqlConnection(DataInfo.connections[DBChecker.ConnectionType]);

            //Checks if the table exists, if it doesn't then it generates it
            if (DBChecker.CheckTableExist("Data"))
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Runs when the worker has completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
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
USE [275Assign5DB]
GO

/****** Object:  Table [dbo].[Data]    Script Date: 2/28/2021 1:34:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Data](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceName] [nvarchar](50) NOT NULL,
	[DeviceType] [nvarchar](50) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[UnitOfMeasure1] [nvarchar](50) NOT NULL,
	[UnitOfMeasureValue1] [decimal](18, 0) NULL,
	[UnitOfMeasure2] [nvarchar](50) NOT NULL,
	[UnitOFMeasureValue2] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Data] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

                  
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
            catch
            {
                //createscheema = false;
                //throw;
            }
            finally
            {
                if(conn.State != ConnectionState.Closed)
                conn.Close();

            }


        }
    }
}
