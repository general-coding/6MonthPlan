using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEH.LambdasAndDelegates
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate bizRulesDelegate)
        {
            var result = bizRulesDelegate(x, y);
            Console.WriteLine(result);
        }
    }
}
