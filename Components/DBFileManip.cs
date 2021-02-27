using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotData.Components
{
    /// <summary>
    /// Houses the background worker and methods that have to do with the Database
    /// </summary>
    public class DBFileManip
    {
        //background worker shenanagins? i think? kek
        Queue<DataSchema> ToDBQ = new Queue<DataSchema>();

        public DBFileManip()
        {

        }

        public void startfileworker()
        {
            //bgw.RunWorkerAsync();
        }

        //talking to and writing to the database
    }
}
