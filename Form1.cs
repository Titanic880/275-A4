using System;
using IotData.Components;
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

        /// <summary>
        /// Main instance of the DBFile Manip
        /// </summary>
        DBFileManip dbManip = null;
        DataGenerator DataGen = null;
        LocalFileManip LocalManip = null;


        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            Setup();


        }
        /// <summary>
        /// Primary Initilization Codes
        /// </summary>
        private void Setup()
        {
            LocalFileManip.FileCheck();
            dbManip = new DBFileManip();
            DataGen = new DataGenerator();
            LocalManip = new LocalFileManip();


            bool connect = DBChecker.Connected();

            //Checks whether or not Connection is active or not
           if (connect)
           {
                
                //dbManip.SelectAllFromDatabase();
                
                ///need to sill populate table with data in ToDatbaseQ
                ///and make sure of the timer tick

                // DataInfo.ToDatabaseQ

          }

        }
        /// <summary>
        /// Initilizes the Program start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInit_Click(object sender, EventArgs e)
        {
            // DataSchema ds = new DataSchema();

            /// sooooo i believe we want to summon the background worker here
            ///though i want to say the background worker will be living in its own seperate class
            ///im going to guess thats what DBFileManip is about,
            ///so im going to be treating dbfilemanp as its  a background worker with its sperarate methods


            dbManip.StartFileWorker();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DataGen.Stop();
            LocalManip.Stop();
            dbManip.StopFileWorker();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataGen.Completed)
            {
                //DO STUFF EHRE
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbManip.SelectAllFromDatabase();

            
        }
    }
}
