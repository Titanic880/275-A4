﻿using System;
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
    /// 
    /// </summary>
    public class DBFileManip
    {
        //background worker shenanagins? i think? kek
        Queue<DataSchema> ToDBQ = new Queue<DataSchema>();

        string connectionString = ConfigurationManager.ConnectionStrings["labString"].ConnectionString;

        SqlConnection conn;


        public DBFileManip()
        {

        }

        public void startfileworker()
        {
            //bgw.RunWorkerAsync();
        }

        // im using this as a tester, just making sure the manual way works first before we get fancy
        public DataTable SelectAllFromDatabase()
        {
            DataTable ret = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * From Data", conn);
           // cmd.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
          //  cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ret);
            return ret;
        }






        //talking to and writing to the database


        // mitch btw heres a hard copy of the database script,
        //rn im at the part where i need to see if this database exists and 
        //if it doesnt write to it, and if not create it, but im not quite sure how to access 
        //the db checker stuff cus its static and love a refresher on it

       
//        USE[master]
// GO

///****** Object:  Database [275Assign5DB]    Script Date: 2/28/2021 3:50:14 AM ******/
//CREATE DATABASE[275Assign5DB]
// CONTAINMENT = NONE
// ON  PRIMARY
//(NAME = N'275Assign5DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\275Assign5DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
// LOG ON
//(NAME = N'275Assign5DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\275Assign5DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
//GO

//ALTER DATABASE[275Assign5DB] SET COMPATIBILITY_LEVEL = 140
//GO

//IF(1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
//begin
//EXEC[275Assign5DB].[dbo].[sp_fulltext_database] @action = 'enable'
//end
//GO

//ALTER DATABASE[275Assign5DB] SET ANSI_NULL_DEFAULT OFF
//GO

//ALTER DATABASE[275Assign5DB] SET ANSI_NULLS OFF
//GO

//ALTER DATABASE[275Assign5DB] SET ANSI_PADDING OFF
//GO

//ALTER DATABASE[275Assign5DB] SET ANSI_WARNINGS OFF
//GO

//ALTER DATABASE[275Assign5DB] SET ARITHABORT OFF
//GO

//ALTER DATABASE[275Assign5DB] SET AUTO_CLOSE OFF
//GO

//ALTER DATABASE[275Assign5DB] SET AUTO_SHRINK OFF
//GO

//ALTER DATABASE[275Assign5DB] SET AUTO_UPDATE_STATISTICS ON
//GO

//ALTER DATABASE[275Assign5DB] SET CURSOR_CLOSE_ON_COMMIT OFF
//GO

//ALTER DATABASE[275Assign5DB] SET CURSOR_DEFAULT  GLOBAL
//GO

//ALTER DATABASE[275Assign5DB] SET CONCAT_NULL_YIELDS_NULL OFF
//GO

//ALTER DATABASE[275Assign5DB] SET NUMERIC_ROUNDABORT OFF
//GO

//ALTER DATABASE[275Assign5DB] SET QUOTED_IDENTIFIER OFF
//GO

//ALTER DATABASE[275Assign5DB] SET RECURSIVE_TRIGGERS OFF
//GO

//ALTER DATABASE[275Assign5DB] SET DISABLE_BROKER
//GO

//ALTER DATABASE[275Assign5DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
//GO

//ALTER DATABASE[275Assign5DB] SET DATE_CORRELATION_OPTIMIZATION OFF
//GO

//ALTER DATABASE[275Assign5DB] SET TRUSTWORTHY OFF
//GO

//ALTER DATABASE[275Assign5DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
//GO

//ALTER DATABASE[275Assign5DB] SET PARAMETERIZATION SIMPLE
//GO

//ALTER DATABASE[275Assign5DB] SET READ_COMMITTED_SNAPSHOT OFF
//GO

//ALTER DATABASE[275Assign5DB] SET HONOR_BROKER_PRIORITY OFF
//GO

//ALTER DATABASE[275Assign5DB] SET RECOVERY FULL
//GO

//ALTER DATABASE[275Assign5DB] SET  MULTI_USER
//GO

//ALTER DATABASE[275Assign5DB] SET PAGE_VERIFY CHECKSUM
//GO

//ALTER DATABASE[275Assign5DB] SET DB_CHAINING OFF
//GO

//ALTER DATABASE[275Assign5DB] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF)
//GO

//ALTER DATABASE[275Assign5DB] SET TARGET_RECOVERY_TIME = 60 SECONDS
//GO

//ALTER DATABASE[275Assign5DB] SET DELAYED_DURABILITY = DISABLED
//GO

//ALTER DATABASE[275Assign5DB] SET QUERY_STORE = OFF
//GO

//USE[275Assign5DB]
//GO

//ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
//        GO

//        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
//GO

//ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
//GO

//ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
//GO

//ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
//GO

//ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
//GO

//ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
//GO

//ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
//GO

//ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
//GO

//ALTER DATABASE[275Assign5DB] SET  READ_WRITE
//GO



        ///




    }
}
