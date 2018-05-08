using Newtonsoft.Json;

namespace OandaTest.Entity.OrderRequest
{
    public abstract class OrderRequest
    {
        [JsonProperty("type")]
        public string Type;
        
        [JsonProperty("instrument")]
        public string Instrument;
        
        [JsonProperty("units")]
        public string Units;
        
        [JsonProperty("id")]
        public string Id;
    }
}