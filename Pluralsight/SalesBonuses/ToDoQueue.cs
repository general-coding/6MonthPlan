using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Pluralsight.ConcurrentCollections.SalesBonuses
{
    public class ToDoQueue
    {
        private readonly BlockingCollection<Trade> _queue
            = new BlockingCollection<Trade>(new ConcurrentQueue<Trade>());
        private readonly StaffLogsForBonuses _staffLogs;

        public ToDoQueue(StaffLogsForBonuses staffResults)
        {
            _staffLogs = staffResults;
        }

        public void AddTrade(Trade transaction)
        {
            _queue.Add(transaction);
        }

        public void CompleteAdding()
        {
            //Tells the BlockingCollection that no more items to add
            _queue.CompleteAdding();
        }

        public void MonitorAndLogTrades()
        {
            while (true)
            {
                try
                {
                    Trade nextTransaction = _queue.Take();
                    _staffLogs.ProcessTrade(nextTransaction);
                    Console.WriteLine("Processing transaction from " + nextTransaction.Person.Name);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
}