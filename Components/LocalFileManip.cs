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
        BackgroundWorker wkr = new BackgroundWorker();
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

            }
            WriteTotal++;
        }

        #region Static
        public static string LocalFile { get; private set; }

        public static void WriteToFile(string Data)
        {
            using (StreamWriter sw = File.AppendText(LocalFile))
                sw.WriteLine(Data);
        }

        public static string[] ReadFromFile(string Path, int Lines)
        {
            string[] ret = new string[Lines];
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
            LocalFile = path;
        }
        #endregion Static
    }
}
