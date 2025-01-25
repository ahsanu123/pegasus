using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ASPNET4InPractice.Chapter15
{
    public class PriceEngine
    {
        public PriceEngine(string flightNumber)
        {
            FlightNumber = flightNumber;
            FlightResults = new ConcurrentQueue<FlightPriceResult>();
        }

        public string FlightNumber { get; private set; }
        public bool Completed { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public ConcurrentQueue<FlightPriceResult> FlightResults { get; private set; }

        public void GetFlightPrices()
        {
            StartTime = DateTime.Now;
            IFlightPriceProvider[] providers = GetProviders().ToArray();
            Task[] handles = new Task[providers.Length];

            for (int i = 0; i<providers.Length; i++)
            {
                handles[i] = Task.Factory.StartNew(currentProvider =>
                      {
                          return ((IFlightPriceProvider)currentProvider).GetFlightPrice(FlightNumber);
                      },
                      providers[i]
                    );
            }

            Task.Factory.ContinueWhenAll(handles.ToArray(), tasks =>
                {
                    foreach (Task<FlightPriceResult> task in tasks)
                        FlightResults.Enqueue(task.Result);

                    EndTime = DateTime.Now;
                    Completed = true;
                }
            );
        }

        private IEnumerable<IFlightPriceProvider> GetProviders()
        {
            // load from configirutation
            return new IFlightPriceProvider[] {
				new FirstProvider(), new SecondProvider() ,
			new FirstProvider(), new SecondProvider(),
			new FirstProvider(), new SecondProvider(),
			new FirstProvider(), new SecondProvider(),
			new FirstProvider(), new SecondProvider(),
			new FirstProvider(), new SecondProvider(),
			new FirstProvider(), new SecondProvider()
			};
        }
    }
}