﻿using System;

namespace IotData.Components
{
    ///The data Schema for generating the Data used
    public class DataSchema
    {

        readonly string DeviceName = null;
        readonly DataInfo.DataType DeviceType;
        string UOM1 = null;
        string UOM2 = null;

        decimal UOM1Value = 0;
        decimal UOM2Value = 0;
        DateTime TimeStamp;

        /// <summary>
        /// Returns a string of the Datafile
        /// </summary>
        /// <returns></returns>
        public string GetInformation()
        {                                               //2021-03-02 12:42:40 AM
            return $"{DeviceName},{DeviceType},{TimeStamp.ToString(System.Globalization.CultureInfo.InvariantCulture)},{UOM1},{UOM1Value},{UOM2},{UOM2Value}";
        }

        public DataSchema(string dName, DataInfo.DataType Type)
        {
            DeviceName = dName;
            DeviceType = Type;

            switch (Type)
            {
                case DataInfo.DataType.GPS:
                    GenerateGPSData();
                    break;
                case DataInfo.DataType.Electric:
                    GenerateElectricData();
                    break;
                case DataInfo.DataType.Water:
                    GenerateWaterData();
                    break;
                case DataInfo.DataType.Gas:
                    GenerateGasData();
                    break;
            }
        }

        /// <summary>
        /// Reloads a schema from a string input
        /// </summary>
        /// <param name="Reload"></param>
        public DataSchema(string Reload)
        {
            string[] vals = Reload.Split(',');
            DeviceName = vals[0];
            switch (vals[1])
            {
                case "GPS":
                    DeviceType = DataInfo.DataType.GPS;
                    break;
                case "Electric":
                    DeviceType = DataInfo.DataType.Electric;
                    break;
                case "Water":
                    DeviceType = DataInfo.DataType.Water;
                    break;
                case "Gas":
                    DeviceType = DataInfo.DataType.Gas;
                    break;
            }
            TimeStamp = DateTime.ParseExact(vals[2], "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            UOM1 = vals[3];
            UOM1Value = Convert.ToDecimal(vals[4]);
            UOM2 = vals[5];
            UOM2Value = Convert.ToDecimal(vals[6]);
        }

        private void GenerateElectricData()
        {
            UOM1 = "kWH";
            UOM2 = "kVA";
            GenerateData(13,4, 100000,1,1);
        }
        private void GenerateGasData()
        {
            UOM1 = "CF";
            UOM2 = "PSI";
            GenerateData(1, 1, 100000);            
        }
        private void GenerateWaterData()
        {
            UOM1 = "CM"; 
            UOM2 = "TEMPCelsius"; 
            GenerateData(1, 1, 100000); 
        }
        private void GenerateGPSData()
        {
            UOM1 = "Latitude";
            UOM2 = "Longitude";
            GenerateData(52, -109, 100000000 ,19, -111);
        }
        internal void GenerateData( int UOMax1, int UOMax2, int upperLimit = 100000, int UOMin1 = 0, int UOMin2 = 0)
        {
            TimeStamp = DateTime.Now;
            string tmp = TimeStamp.ToString();

            UOM1Value = decimal.Parse(DataInfo.rand.Next(UOMin1, UOMax1) + "." + DataInfo.rand.Next(0, upperLimit));
            UOM2Value = decimal.Parse(DataInfo.rand.Next(UOMin2, UOMax2) + "." + DataInfo.rand.Next(0, upperLimit));
        }
    }
}
