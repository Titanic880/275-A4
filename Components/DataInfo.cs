using System;
using System.Configuration;

namespace IotData.Components
{/// <summary>
 /// Handles and stores environment variables
 /// </summary>
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
}
