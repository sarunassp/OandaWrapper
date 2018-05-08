using System;
using System.Globalization;
using Newtonsoft.Json;

namespace OandaTest.Entity.OrderRequest
{
    public class LimitOrderRequestRequest : OrderRequest
    {
        [JsonProperty ("price")]
        public string Price;

        [JsonProperty ("timeInOrder")]
        public DateTime TimeInOrder;
        
        public LimitOrderRequestRequest
        (
            string instrument,
            uint units,
            decimal price,
            DateTime timeInOrder
        )
        {
            Type = OrderType.Limit;
            Instrument = instrument;
            Units = units.ToString ();
            Price = price.ToString (CultureInfo.InvariantCulture);
            TimeInOrder = timeInOrder;
        }
    }
}