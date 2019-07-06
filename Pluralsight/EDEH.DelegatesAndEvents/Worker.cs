using System;

namespace EDEH.DelegatesAndEvents
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;

        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //Raise event work performed
                OnWorkPerformed(i + 1, workType);
            }

            //Raise event work completed
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            if (WorkPerformed is WorkPerformedHandler del)
            {
                del(hours, workType);
            }
        }

        protected virtual void OnWorkCompleted()
        {
            //if(WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}

            if (WorkCompleted is EventHandler del)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
