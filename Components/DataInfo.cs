using System;
using System.Configuration;
using System.Collections.Generic;

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
        public readonly static int DeviceCount = int.Parse(ConfigurationManager.AppSettings.Get("deviceCount"));
        /// <summary>
        /// The delay of data
        /// </summary>
        public readonly static int dataDelay = int.Parse(ConfigurationManager.AppSettings.Get("dataDelayMillis"));
        /// <summary>
        /// The different types of connection
        /// </summary>
        public readonly static string[] connections =
        {
            ConfigurationManager.ConnectionStrings["labString"].ConnectionString,
            ConfigurationManager.ConnectionStrings["DockerStr"].ConnectionString
        };
        /// <summary>
        /// The number of threads avaliable for background workers
        /// </summary>
        public static readonly int ThreadsForWorkers = Environment.ProcessorCount - 4;

        /// <summary>
        /// The queue that is written to from the generator
        /// </summary>
        public static Queue<DataSchema> InitialQueue = new Queue<DataSchema>();
        /// <summary>
        /// if the database is not found then the schema is loaded into this queue
        /// </summary>
        public static Queue<DataSchema> ToDatabaseQ = new Queue<DataSchema>();
        /// <summary>
        /// Overflow is for when a insert Fails
        /// </summary>
        public static Queue<DataSchema> OverflowQ = new Queue<DataSchema>();

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
    }
}
