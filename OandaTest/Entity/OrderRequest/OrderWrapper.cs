using Newtonsoft.Json;

namespace OandaTest.Entity.OrderRequest
{
    public class OrderWrapper
    {
        [JsonProperty("order")]
        public Order.Order Order;
    }
}