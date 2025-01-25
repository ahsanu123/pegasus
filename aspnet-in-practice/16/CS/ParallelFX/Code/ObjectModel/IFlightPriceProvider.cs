using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET4InPractice.Chapter15
{
    public interface IFlightPriceProvider
    {
        FlightPriceResult GetFlightPrice(string FlightNumber);
    }
}