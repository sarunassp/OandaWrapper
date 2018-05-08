using System;
using System.Globalization;
using Newtonsoft.Json;

namespace OandaTest.Entity.OrderRequest
{
    public class MarketOrderRequestRequest : OrderRequest
    {
        [JsonProperty ("timeInForce")]
        public DateTime TimeInForce { get; }

        public MarketOrderRequestRequest
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