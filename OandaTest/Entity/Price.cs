using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OandaTest.Entity
{
    public class Price
    {
        [JsonProperty ("instrument")]
        public string Instrument;

        [JsonProperty("bids")]
        public IEnumerable<PriceQuotation> Bids;
        
        [JsonProperty("asks")]
        public IEnumerable<PriceQuotation> Asks;

        [JsonProperty("time")]
        public DateTime Time;
    }

    public class PriceQuotation
    {
        [JsonProperty ("price")]
        public string Price;

        [JsonProperty ("liquidity")]
        public int Liquidity;
    }

    public class PriceWrapper
    {
        [JsonProperty("prices")]
        public IEnumerable<Price> Prices;

        [JsonProperty("time")]
        public DateTime Time;
    }
}