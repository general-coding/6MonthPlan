using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class AsyncBad : Form
    {
        private delegate void UpdateProgressDelegate(int val);

        public AsyncBad()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new AsyncBad());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            UpdateProgressDelegate updateProgressDelegate
                = new UpdateProgressDelegate(StartProcess);
            updateProgressDelegate.BeginInvoke(100, null, null);
            MessageBox.Show("Done with operation!");
        }

        //Called Asynchronously
        //This is BAD because helper thread is updating UI components directly
        private void StartProcess(int max)
        {
            pbStatus.Maximum = max;
            for (int i = 0; i <= max; i++)
            {
                Thread.Sleep(10);
                lblOutput.Text = i.ToString();
                pbStatus.Value = i;
            }
        }
    }
}
