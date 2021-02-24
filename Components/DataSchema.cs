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
}
}
