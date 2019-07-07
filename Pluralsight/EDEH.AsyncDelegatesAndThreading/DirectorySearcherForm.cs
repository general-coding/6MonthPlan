using System;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class DirectorySearcherForm : Form
    {
        public DirectorySearcherForm()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new DirectorySearcherForm());
        }

        private void directorySearcher_SearchComplete(object sender, EventArgs e)
        {
            SearchLabel.Text = string.Empty;
        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            directorySearcher.SearchCriteria = searchText.Text;
            SearchLabel.Text = "Searching...";
            directorySearcher.BeginSearch();
        }
    }
}
