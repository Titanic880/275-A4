using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotData.Components
{
    ///The data Schema for generating the Data used
    public class DataSchema
    {
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
        public DataSchema(string Name, DataType dt, int Measure1, int MeasureValue1, int Measure2, int MeasureValue2)
        {

        }
        static Random rand = new Random();
        private string DeviceName = "";
        private string DeviceType = "";
        private string UOM1 = "";
        private string UOM2 = "";
        private decimal UOM1Value = 0;
        private decimal UOM2Value = 0;
        private DateTime TimeStamp;

        public override string ToString()
        {
            return DeviceName + "," + DeviceType + "," + TimeStamp.ToString("yyyyMMdd HH:mm:ss") + "," + UOM1 + "," + UOM1Value + "," + UOM2 + "," + UOM2Value + Environment.NewLine;
        }
        public DataSchema(string dName, string dType)
        {
            this.DeviceName = dName;
            this.DeviceType = dType;

            if (dType == "GPS")
            {
                GenerateGPSData();
            }
            else if (dType == "H2O")
            {
                GenerateWaterData();
            }
            else if (dType == "Gas")
            {
                GenerateGasData();
            }
            else if (dType == "ELECTRIC")
            {
                GenerateElectricData();
            }
        }
        public void GenerateElectricData()
        {
            UOM1 = "kWH";
            UOM2 = "kVA";
            UOM1Value = Decimal.Parse(rand.Next(1, 13) + "." + rand.Next(0, 100000));
            UOM2Value = Decimal.Parse(rand.Next(1, 4) + "." + rand.Next(0, 100000));
        }
        public void GenerateGasData()
        {
            UOM1 = "CF";
            UOM2 = "PSI";

            UOM1Value = Decimal.Parse(rand.Next(0, 1) + "." + rand.Next(0, 100000));
            UOM2Value = Decimal.Parse("1." + rand.Next(0, 100000));

        }
        public void GenerateWaterData()
        {
            UOM1 = "CM";
            UOM2 = "TEMPCelsius";
            UOM1Value = Decimal.Parse(rand.Next(0, 1) + "." + rand.Next(0, 100000));
            UOM2Value = Decimal.Parse(rand.Next(0, 35) + "." + rand.Next(0, 100000));
        }
        public void GenerateGPSData()
        {
            UOM1 = "Latitude";
            UOM2 = "Longitude";
            TimeStamp = DateTime.Now;
            UOM1Value = Decimal.Parse(rand.Next(19, 52).ToString() + "." + rand.Next(0, 100000000).ToString());
            UOM2Value = Decimal.Parse(rand.Next(-111, -109).ToString() + "." + rand.Next(0, 100000000).ToString());
        }
    }
}
