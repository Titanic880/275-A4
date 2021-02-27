using System;
using System.Configuration;

namespace IotData.Components
{/// <summary>
 /// Handles and stores environment variables
 /// </summary>
    public static class DataInfo
    {
        public readonly static string Datapath = ConfigurationManager.AppSettings.Get("fileDirectory");
        public readonly static string DataFile = ConfigurationManager.AppSettings.Get("filePath");
        public readonly static int DeviceCount= int.Parse(ConfigurationManager.AppSettings.Get("deviceCount"));
        public readonly static int dataDelay = int.Parse(ConfigurationManager.AppSettings.Get("dataDelayMillis"));

        public static readonly int CPUCORES = Environment.ProcessorCount - 2;

        /// <summary>
        /// The Type of device
        /// </summary>
        public enum DataType
        {
            GPS,
            Electric,
            Water,
            Gas
        }

        public static readonly Random rand = new Random();

        //make number to equal how many threads, when a process is finished it either incruiments or decriments
        //2 for timeer
        //2 for comp

        //generic info
        // were using this cus went talk to the form nicely



    }
}
