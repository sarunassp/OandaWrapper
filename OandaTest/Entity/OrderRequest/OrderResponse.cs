﻿using Newtonsoft.Json;

namespace OandaTest.Entity.OrderRequest
{
    public class OrderResponse<T> where T: OrderRequest
    {
        [JsonProperty("orderCreateTransaction")]
        public T Order;
    }
}