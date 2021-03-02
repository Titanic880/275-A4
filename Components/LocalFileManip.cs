using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotData.Components
{
    public class LocalFileManip
    {
        readonly BackgroundWorker wkr = new BackgroundWorker();
        public bool Completed { get; private set; } = false;
        public ulong WriteTotal { get; private set; } = 0;
        public LocalFileManip()
        {
            wkr.DoWork += Wkr_DoWork;
            wkr.RunWorkerCompleted += Wkr_RunWorkerCompleted;
            wkr.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Starts the worker
        /// </summary>
        public void Start()
        {
            if (!wkr.IsBusy)
                wkr.RunWorkerAsync();
        }

        /// <summary>
        /// Stops the worker 
        /// </summary>
        public void Stop()
        {
            if (!wkr.CancellationPending)
                wkr.CancelAsync();
        }

        private void Wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Completed = true;
        }

        private void Wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!wkr.CancellationPending)
            {
                //Checks the overflow Queue
                if (DataInfo.OverflowQ.Count != 0)
                {
                    for (int i = 0; i < DataInfo.OverflowQ.Count; i++)
                        using (StreamWriter sw = new StreamWriter(LocalDir + LocalFileName))
                            sw.WriteLine(DataInfo.OverflowQ.Dequeue().GetInformation());
                }
                if (DataInfo.InitialQueue.Count != 0)
                { 
                    //Checks that the database is offline
                    if (!DataInfo.Connected)
                    {
                        //Writes a dataSchema to the file if the database is not found
                        using (StreamWriter sw = new StreamWriter(LocalDir + LocalFileName))
                            sw.WriteLine(DataInfo.InitialQueue.Dequeue().GetInformation());
                    }
                    //if the db is found then it shifts one line from the datafile into the db queue 
                    //(might change the size of the move depending on effeciency)
                    else
                    {
                        using (StreamReader sr = new StreamReader(LocalDir + LocalFileName))
                        {
                            string tmp = sr.ReadLine();
                            if (tmp == null)
                            {   //If the file is empty it will push a Schema from the inital to the Db Queue
                                DataInfo.ToDatabaseQ.Enqueue(DataInfo.InitialQueue.Dequeue());
                            }
                            else
                            {   //Otherwise it will pull from the file
                                DataInfo.ToDatabaseQ.Enqueue(new DataSchema(tmp));
                            }
                        }
                    }
                    WriteTotal++;
                }
            }
        }

        #region Static
        public static string LocalFileName { get; private set; } = "stor.csv";
        public static string LocalDir { get; private set; } = "Local";

        public static void WriteToFile(string Data)
        {
            using (StreamWriter sw = File.AppendText(LocalFileName))
                sw.WriteLine(Data);
        }

        public static void SetLocalFile(string path)
        {
            LocalFileName = path;
        }

        public static void SetLocalDirectory(string Dir)
        {
            LocalDir = Dir;
        }

        /// <summary>
        /// Checks for the DataFile and generates if not found
        /// </summary>
        public static string FileCheck()
        {
            return FileCheck(LocalDir+LocalFileName);
        }
        public static string FileCheck(string FilePath)
        {
            string ret = null;
            if (!Directory.Exists(LocalDir))
            {
                Directory.CreateDirectory(LocalDir);
                File.Create(FilePath).Close();
                ret = "Data file was not found, new one created";
            }
            else if (!File.Exists(FilePath))
                File.Create(FilePath).Close();

            return ret;
        }
        #endregion Static
    }
}
