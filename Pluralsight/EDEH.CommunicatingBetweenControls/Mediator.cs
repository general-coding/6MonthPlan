using EDEH.CommunicatingBetweenControls.Model;
using System;

namespace EDEH.CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        private static readonly Mediator _Instance = new Mediator();

        private Mediator()
        {

        }

        public static Mediator GetInstance()
        {
            return _Instance;
        }

        //Instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangedDelegate != null)
            {
                jobChangedDelegate(sender, new JobChangedEventArgs { Job = job });
            }
        }
    }
}
