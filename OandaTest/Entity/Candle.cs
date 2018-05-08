using System;
using Newtonsoft.Json;

namespace OandaTest.Entity
{
    public class Candle
    {
        [JsonProperty("complete")]
        public bool IsCompleted;
        
        [JsonProperty("volume")]
        public string Volume;
        
        [JsonProperty("Time")]
        public DateTime Time;

        [JsonProperty("mid")]
        public CandlePrices Prices;
    }

    public class CandlePrices
    {
        [JsonProperty("o")]
        public string Open;
        
        [JsonProperty("h")]
        public string High;
        
        [JsonProperty("l")]
        public string Low;
        
        [JsonProperty("c")]
        public string Close;
    }
}
