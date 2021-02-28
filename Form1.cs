using IotData.Components;
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

        //put all vals from the config file
        readonly string filePath = ConfigurationManager.AppSettings.Get("filePath");
        readonly string fileDirectory = ConfigurationManager.AppSettings.Get("fileDirectory");
        readonly int deviceCount = int.Parse(ConfigurationManager.AppSettings.Get("deviceCount"));
        readonly int dataDelay = int.Parse(ConfigurationManager.AppSettings.Get("dataDelayMillis"));


        public Form1()
        {
            InitializeComponent();
            
           LocalFileManip.FileCheck();

            this.MaximizeBox = false;


            if (Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            
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
