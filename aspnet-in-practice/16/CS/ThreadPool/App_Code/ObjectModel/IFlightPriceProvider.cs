using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IFlightPriceProvider
{
	FlightPriceResult GetFlightPrice(string flightNumber);
}
