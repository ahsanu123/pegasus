using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace ASPNET4InPractice.Chapter15
{
    public class FirstProvider : IFlightPriceProvider
    {
        public FlightPriceResult GetFlightPrice(string FlightNumber)
        {
            // let's simulate a call to a remote resource
            Thread.Sleep(2000);

            // and return a fixed value
            return new FlightPriceResult() { FlightNumber = FlightNumber, Price = 560 };
        }

    }

}