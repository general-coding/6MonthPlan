namespace Pluralsight.ConcurrentCollections.DictionaryPerformance
{
    public static class Worker
	{
		public static int DoSomethingTimeConsuming()
		{
			int total = 0;
			for (int i = 0; i < 1000; i++)
				total += i;
			return total;
		}
	}
}