using System.Collections.Generic;
using Newtonsoft.Json;

namespace OandaTest.Entity.Order
{
    public class OrdersList
    {
        [JsonProperty("orders")]
        public IEnumerable<Order> Orders;
    }
}