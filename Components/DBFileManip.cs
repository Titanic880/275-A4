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
            if (DBChecker.ConnectionType == -1)
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
        //bool createscheema = true;

        public void CreateDataTable()
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
            //CREATE TABLE 275Assign5DB.dbo.Data
            //      (
            //          Name varchar(50) NOT NULL,
            //          Phone varchar(11) NOT NULL,
            //          Email varchar(50) NOT NULL,
            //          Picture varbinary(MAX) NOT NULL,
            //          Message varchar(250) NOT NULL,
            //          SignDatetime datetime NOT NULL
            //       )
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

                conn.Close();

            }


        }
    }
}
