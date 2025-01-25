using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

public class SecondProvider: IFlightPriceProvider
{
	public FlightPriceResult GetFlightPrice(string flightNumber)
	{
		// let's simulate a call to a remote resource
		Thread.Sleep(3000);

		// and return a fixed value
		return new FlightPriceResult() { FlightNumber = flightNumber, Price = 260 };
	}

}