using System;
using System.Globalization;
using Newtonsoft.Json;

namespace OandaTest.Entity.OrderRequest
{
    public class MarketOrderRequest : OrderRequest
    {
        [JsonProperty ("timeInForce")]
        public DateTime TimeInForce { get; }

        public MarketOrderRequest
        (
            string instrument,
            uint units,
            DateTime timeInForce
        )
        {
            Type = OrderType.Market;
            Instrument = instrument;
            Units = units.ToString ();
            TimeInForce = timeInForce;
        }
    }
}