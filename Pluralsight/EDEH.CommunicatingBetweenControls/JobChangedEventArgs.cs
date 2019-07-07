using EDEH.CommunicatingBetweenControls.Model;
using System;

namespace EDEH.CommunicatingBetweenControls
{
    public class JobChangedEventArgs : EventArgs
    {
        public Job Job { get; set; }
    }
}
