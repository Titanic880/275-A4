using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotData.Components
{
    /// <summary>
    /// Used to Check if the database exists
    /// </summary>
    public class DBChecker
    {
        //Create either a timer or a background worker to check every 1-5 seconds
        //a method from here is called if the background worker in DBFileManip returns false
        
        public DBChecker()
        {

        }


        /// <summary>
        /// Checks what form of the database to use
        /// </summary>
        /// <returns></returns>
        public static bool CheckDataBaseType()
        {
            throw new NotImplementedException();
        }
    }
}
