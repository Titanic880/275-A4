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

        public void Start()
        {
            wkr.RunWorkerAsync();
        }
        public void Stop()
        {
            wkr.CancelAsync();
        }
        private void Wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = int.MaxValue; i > 0; i-=2)
            {
                DataInfo.ToDBQ.Enqueue(new DataSchema(i.ToString(), (DataInfo.DataType)DataInfo.rand.Next(4)));
                DataInfo.ToDBQ.Enqueue(new DataSchema(i.ToString(), (DataInfo.DataType)DataInfo.rand2.Next(4)));
            }
        }
        private void Wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Completed = true;
        }

    }
}
