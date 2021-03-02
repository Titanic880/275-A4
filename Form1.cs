using System;
using IotData.Components;
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
                MessageBox.Show("You are connected!");
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
            //finished
            DataGen.Stop();
            LocalManip.Stop();
            dbManip.StopFileWorker();
        }

        private void BtnGoOff_Click(object sender, EventArgs e)
        {
            //finished
            DBChecker.DEBUG_SETOFFLINE();
        }

        private void BtnGoOnline_Click(object sender, EventArgs e)
        {
            //finished
            DBChecker.DEBUG_SETONLINE();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataGen.Completed)
            {
                //DO STUFF EHRE

                dataGridView1.DataSource = dbManip.SelectAllFromDatabase();



            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbManip.SelectAllFromDatabase();

            
        }


    }
}
