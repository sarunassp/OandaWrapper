using Newtonsoft.Json;

namespace OandaTest.Entity.OrderRequest
{
    public class OrderWrapper<T>
    {
        [JsonProperty("order")]
        public T Order;
    }
}