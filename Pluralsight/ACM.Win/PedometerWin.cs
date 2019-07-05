using ACM.BL;
using System;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class PedometerWin : Form
    {
        public PedometerWin()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            try
            {
                decimal result = customer.CalculatePercentOfGoalSteps(GoalTextBox.Text,
                                                        StepsTextBox.Text);

                ResultLabel.Text = "You reached " + result + "% of your goal!";

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Your entry was not valid: " + ex.Message);
                ResultLabel.Text = string.Empty;
            }
        }
    }
}
