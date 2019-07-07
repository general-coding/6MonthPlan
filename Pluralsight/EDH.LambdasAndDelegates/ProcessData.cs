using System;

namespace EDEH.LambdasAndDelegates
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate bizRulesDelegate)
        {
            var result = bizRulesDelegate(x, y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been processed");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> bizRulesDelegate)
        {
            var result = bizRulesDelegate(x, y);
            Console.WriteLine(result);
        }
    }
}
