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
            }
            else
            {
                MessageBox.Show("You have not connected; Check your connection String.");
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
            dbManip.Start();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //finished
            DataGen.Stop();
            LocalManip.Stop();
            dbManip.Stop();
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
                MessageBox.Show("Data Generation has Stopped/Completed");
            }
            if (dbManip.Completed)
            {
                MessageBox.Show("Database Systems has Stopped");
            }
            if (LocalManip.Completed)
            {
                MessageBox.Show("Local File Systems has Stopped");
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbManip.SelectAllFromDatabase();
        }


    }
}
