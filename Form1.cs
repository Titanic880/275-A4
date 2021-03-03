using System;
using IotData.Components;
using System.Windows.Forms;
using System.Drawing;

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
            BtnInit.BackColor = Color.MediumSpringGreen;
            BtnCancel.BackColor = Color.IndianRed;
            BtnGoOnline.BackColor = Color.CadetBlue;
            BtnGoOff.BackColor = Color.CadetBlue;
            button5.BackColor = Color.CadetBlue;
            this.BackColor = Color.DarkSlateGray;
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
                MessageBox.Show("You have not connected, check your connection string!.");
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
            DataGen.Start();
            LocalManip.Start();
            dbManip.Start();
            MessageBox.Show("Generation has Started! :)");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //finished!
            DataGen.Stop();
            LocalManip.Stop();
            dbManip.Stop();
            MessageBox.Show("Database is stopping! :)");
        }

        private void BtnGoOff_Click(object sender, EventArgs e)
        {
            //finished!
            DBChecker.DEBUG_SETOFFLINE();
            MessageBox.Show("Database is going offline! :)");
        }

        private void BtnGoOnline_Click(object sender, EventArgs e)
        {
            //finished!
            DBChecker.DEBUG_SETONLINE();
            MessageBox.Show("Database is coming online! :)");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DataGen.Completed)
            {
                MessageBox.Show("Data Generation has Stopped/Completed!");
            }
            if (dbManip.Completed)
            {
                MessageBox.Show("Database Systems has Stopped!");
            }
            if (LocalManip.Completed)
            {
                MessageBox.Show("Local File Systems has Stopped!");
            }
        }
    }
}
