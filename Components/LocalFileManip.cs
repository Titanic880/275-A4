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
        public uint WriteTotal { get; private set; } = 0;
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
            if (!wkr.CancellationPending)
            {
                //Checks that the database is offline
                if(!DBChecker.Connected())
                {

                }
                else
                {
                    File.ReadLines(LocalFileName);
                    DataInfo.ToDatabaseQ.Enqueue();
                }
            WriteTotal++;
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

        public static string ReadFromFile(string Path)
        {
            string ret = new string;
            using (StreamReader sr = new StreamReader(Path))
            {
                for (int i = 0; i < Lines; i++)
                {
                    ret[i] = sr.ReadLine();
                }
            }
            return ret;
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
