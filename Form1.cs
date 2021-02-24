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
    public class DataInfo
    {
        public readonly string Datapath;
        public readonly string DataFile;
        public readonly int DeviceCount;
        public readonly int dataDelay;

        public static readonly int CPUCORES = Environment.ProcessorCount - 2;

        public DataInfo()
        {
            Datapath = ConfigurationManager.AppSettings.Get("fileDirectory");
            DataFile = ConfigurationManager.AppSettings.Get("filePath");
            DeviceCount = int.Parse(ConfigurationManager.AppSettings.Get("deviceCount"));
            dataDelay = int.Parse(ConfigurationManager.AppSettings.Get("dataDelayMillis"));
        }
    }
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
            Components.LocalFileManip.FileCheck();

            this.MaximizeBox = false;
        }
    }
}
