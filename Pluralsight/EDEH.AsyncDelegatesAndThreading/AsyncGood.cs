using System.Threading;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class AsyncGood : Form
    {
        private delegate void StartProcessDelegate(int val);

        private delegate void ShowProgressDelegate(int val);

        public AsyncGood()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new AsyncGood());
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            StartProcessDelegate progDel = new StartProcessDelegate(StartProcess);
            progDel.BeginInvoke(100, null, null);
            MessageBox.Show("Done with operation!!");
        }

        //Called Asynchronously
        private void StartProcess(int max)
        {
            ShowProgress(0);
            for (int i = 0; i <= max; i++)
            {
                Thread.Sleep(10);
                ShowProgress(i);
            }
        }

        private void ShowProgress(int i)
        {
            //This is hit if a background thread called ShowProgress
            if (lblOutput.InvokeRequired == true)
            {
                ShowProgressDelegate showProgressDelegate
                    = new ShowProgressDelegate(ShowProgress);
                BeginInvoke(showProgressDelegate, new object[] { i });
            }
            else
            {
                lblOutput.Text = i.ToString();
                pbStatus.Value = i;
            }
        }

    }
}
