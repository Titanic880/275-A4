using System.ComponentModel;

namespace IotData.Components
{
    public class DataGenerator
    {
        private readonly BackgroundWorker wkr = new BackgroundWorker();
        public bool Completed { get; private set; } = false;

        public DataGenerator()
        {
            wkr.DoWork += Wkr_DoWork;
            wkr.RunWorkerCompleted += Wkr_RunWorkerCompleted;
            wkr.WorkerSupportsCancellation = true;
        }

        /// <summary>
        /// Starts the Data Generator
        /// </summary>
        public void Start()
        {
            wkr.RunWorkerAsync();
        }

        /// <summary>
        /// Stops the Data Generator
        /// </summary>
        public void Stop()
        {
            wkr.CancelAsync();
        }

        private void Wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = int.MaxValue; i > 0; i-=2)                  //Essentially an infinite loop
            {
                if (wkr.CancellationPending)                        //if told to stop
                    break;

                DataInfo.DataType dt = (DataInfo.DataType)DataInfo.rand.Next(4);
                
                for (int x = 0; x < DataInfo.DeviceCount; x++)       //Goes through all the devices and generates data for them
                    DataInfo.InitialQueue.Enqueue
                        (new DataSchema(x+"."+i, dt));

                System.Threading.Thread.Sleep(DataInfo.dataDelay);  //Delay between Generations
            }
        }

        private void Wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Completed = true;
        }
    }
}
