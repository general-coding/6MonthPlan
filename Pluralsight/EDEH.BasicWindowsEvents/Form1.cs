using System;
using System.Windows.Forms;

namespace EDEH.BasicWindowsEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CountriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Current index " + CountriesComboBox.SelectedIndex.ToString());
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked me");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X.ToString());
        }

    }
}
