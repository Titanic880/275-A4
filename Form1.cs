﻿using IotData.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IotData
{
    public partial class Form1 : Form
    {
        bool cancel = false;

        public Form1()
        {
            InitializeComponent();
            LocalFileManip.FileCheck();
            

            this.MaximizeBox = false;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // DataSchema ds = new DataSchema();

            // sooooo i believe we want to summon the background worker here
            //though i want to say the background worker will be living in its own seperate class
            //im going to guess thats what DBFileManip is about,
            //so im going to be treating dbfilemanp as its  a background worker with its sperarate methods
            
            DBFileManip fm1 = new DBFileManip();

            fm1.startfileworker();
            bool connect = DBChecker.Connected();

          
            if (connect ==true )
            {
                // need to make the table  in file manip
                fm1.CreateDataTable();
                fm1.SelectAllFromDatabase();
                //need to sill populate table with data in ToDatbaseQ
                //and make sure of the timer tick
               
               // DataInfo.ToDatabaseQ

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            //mitch for this to work on your end, you need to create the database on your end
            // and put in your connection string in app config
            DBFileManip FM = new DBFileManip();
            dataGridView1.DataSource = FM.SelectAllFromDatabase();
            

         

        }
    }
}
