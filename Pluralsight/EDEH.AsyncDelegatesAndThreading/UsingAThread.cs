using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class UsingAThread : Form
    {
        int _Max;

        private delegate void StartProcessHandler();

        public UsingAThread()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new UsingAThread());
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            _Max = 100;
            //Start thread
            Thread thread = new Thread(new ThreadStart(StartProcess));
            thread.Start();
        }

        private void StartProcess()
        {
            if (pbStatus.InvokeRequired)
            {
                StartProcessHandler startProcessHandler
                    = new StartProcessHandler(StartProcess);
                Invoke(startProcessHandler);
            }
            else
            {
                Refresh();
                pbStatus.Maximum = _Max;
                for (int i = 0; i <= _Max; i++)
                {
                    Thread.Sleep(10);
                    lblOutput.Text = i.ToString();
                    pbStatus.Value = i;
                }
            }
        }
    }
}
