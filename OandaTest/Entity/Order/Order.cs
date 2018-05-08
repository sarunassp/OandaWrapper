using System;
using Newtonsoft.Json;

namespace OandaTest.Entity.Order
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty ("createTime")]
        public DateTime CreateTime;

        [JsonProperty("state")]
        public string State;
    }
}