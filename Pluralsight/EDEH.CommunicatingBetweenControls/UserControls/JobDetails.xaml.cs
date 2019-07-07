using System.Windows.Controls;

namespace EDEH.CommunicatingBetweenControls.UserControls
{
    /// <summary>
    /// Interaction logic for JobDetails.xaml
    /// </summary>
    public partial class JobDetails : UserControl
    {
        public JobDetails()
        {
            InitializeComponent();

            Mediator.GetInstance().JobChanged += (sender, eventArgs) =>
            {
                this.DataContext = eventArgs.Job;
            };
        }
    }
}
