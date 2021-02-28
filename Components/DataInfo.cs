using System;
using System.Configuration;

namespace IotData.Components
{/// <summary>
 /// Handles and stores environment variables
 /// </summary>
    public static class DataInfo
    {
        /// <summary>
        /// The full file path for the data File
        /// </summary>
        public readonly static string Datapath = ConfigurationManager.AppSettings.Get("fileDirectory");
        /// <summary>
        /// The file name
        /// </summary>
        public readonly static string DataFile = ConfigurationManager.AppSettings.Get("filePath");
        /// <summary>
        /// The amount of Devices
        /// </summary>
        public readonly static int DeviceCount= int.Parse(ConfigurationManager.AppSettings.Get("deviceCount"));
        /// <summary>
        /// The delay of data
        /// </summary>
        public readonly static int dataDelay = int.Parse(ConfigurationManager.AppSettings.Get("dataDelayMillis"));

        /// <summary>
        /// The number of threads avaliable for background workers
        /// </summary>
        public static readonly int ThreadsForWorkers = Environment.ProcessorCount - 4;

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
        public static readonly Random rand2 = new Random(rand.Next());
        //make number to equal how many threads, when a process is finished it either incruiments or decriments
        //2 for timeer
        //2 for comp

        //generic info
        // were using this cus wen cant talk to the form nicely



    }
}
