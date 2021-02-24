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
        readonly string Datapath = ConfigurationManager.AppSettings.Get("fileDirectory");
        readonly string DataFile = ConfigurationManager.AppSettings.Get("filePath");
        readonly int DeviceCount = int.Parse(ConfigurationManager.AppSettings.Get("deviceCount"));
        readonly int dataDelay = int.Parse(ConfigurationManager.AppSettings.Get("dataDelayMillis"));

        public Form1()
        {
            InitializeComponent();
            //Components.LocalFileManip.FileCheck();

            this.MaximizeBox = false;
        }
    }
}
