using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

public class PriceEngine
{
	public PriceEngine(string flightNumber)
	{
		FlightNumber = flightNumber;
		FlightResults = new List<FlightPriceResult>();
	}

	private object Sync = new object(); 
	public string FlightNumber {get; private set;}
	public bool Completed { get; private set; }
	public DateTime StartTime { get; private set; }
	public DateTime EndTime { get; private set; }
	public List<FlightPriceResult> FlightResults { get; private set; }

	public void GetFlightPrices()
	{
		StartTime = DateTime.Now;
		try
		{
			List<WaitHandle> handles = new List<WaitHandle>();
			foreach (IFlightPriceProvider provider in GetProviders())
			{
				ManualResetEvent handle = new ManualResetEvent(false);
				handles.Add(handle);
				Tuple<IFlightPriceProvider, ManualResetEvent> currentState =
				  new Tuple<IFlightPriceProvider, ManualResetEvent>
																(provider, handle);

				ThreadPool.QueueUserWorkItem(
				  delegate(object state)
				  {
					  Tuple<IFlightPriceProvider, ManualResetEvent> invokeState =
						(Tuple<IFlightPriceProvider, ManualResetEvent>)state;

					  FlightPriceResult result = null;
					  IFlightPriceProvider currentProvider = invokeState.Item1;
					  result = currentProvider.GetFlightPrice(FlightNumber);

					  // entering a lock
					  bool lockTaken = false;
					  Monitor.Enter(Sync, ref lockTaken);
					  try
					  {
						  // only a thread can modify the List
						  FlightResults.Add(result);
					  }
					  finally
					  {
						  // closing the lock, using a try...finally to avoid deadlocks
						  if (lockTaken)
								Monitor.Exit(Sync);
					  }

					  ManualResetEvent resetHandle = invokeState.Item2;
					  resetHandle.Set();
				  }, currentState
				);
			}
			// finally, re-join the threads
			WaitHandle.WaitAll(handles.ToArray());

		}
		finally
		{
			EndTime = DateTime.Now;
			Completed = true;
		}
	}

	private IEnumerable<IFlightPriceProvider> GetProviders()
	{
		// load from web.config
		return new IFlightPriceProvider[] {
			new FirstProvider(), new SecondProvider(),
            new FirstProvider(), new SecondProvider(),
        new FirstProvider(), new SecondProvider(),
        new FirstProvider(), new SecondProvider(),
        new FirstProvider(), new SecondProvider(),
        new FirstProvider(), new SecondProvider(),
        new FirstProvider(), new SecondProvider()
		};
	}
}