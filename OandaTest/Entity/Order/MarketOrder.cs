using System;
using Newtonsoft.Json;

namespace OandaTest.Entity.Order
{
    public class MarketOrder : Order
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("instrument")]
        public string Instrument;

        [JsonProperty("units")]
        public double Units;

        [JsonProperty("TimeInForce")]
        public DateTime TimeInForce;
    }
}