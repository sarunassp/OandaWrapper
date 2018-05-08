using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OandaTest.Entity;
using OandaTest.Entity.Order;
using OandaTest.Entity.OrderRequest;

namespace OandaTest.Repository
{
    public class OrderRepository
    {
        private readonly RestClient m_client;

        public OrderRepository ()
        {
            m_client = new RestClient ();
        }
        
        public async Task<IEnumerable<Order>> GetOrders ()
        {
            var result = await m_client.GetAsync<OrdersList, Error> ($"accounts/{Constants.AccountId}/orders");
            return result.Item1.Orders;
        }
    
        public async Task<T> CreateOrder<T> (T order) where T: OrderRequest
        {
            var result = await m_client.PostAsync <OrderResponse<T>, Error> ($"accounts/{Constants.AccountId}/orders", new {order = order});
            return result.Item1.Order;
        }

        public async Task<bool> CancelOrder (string orderId)
        {
            var result = await m_client.PostAsync <object, Error> ($"accounts/{Constants.AccountId}/orders/{orderId}/cancel", null);
            if (result.Item1 != null)
                return true;
            
            return false;
        }

        public async Task<Order> GetOrder (string orderId)
        {
            var result = await m_client.GetAsync <OrderWrapper, Error> ($"accounts/{Constants.AccountId}/orders/{orderId}");
            return result.Item1.Order;
        }

        public async Task<IEnumerable<Candle>> GetPrices (string instrument, string granularity = null, string from = null, string to = null)
        {
            var path = $"instruments/{instrument}/candles";
            var pathToAdd = "?";
            if (granularity != null || from != null || to != null)
            {
                path += $"granularity={granularity}" ?? "";
                if (pathToAdd != "?")
                    pathToAdd += ",";
                path += $"from={from}" ?? "";
                if (pathToAdd != "?")
                    pathToAdd += ",";
                path += $"to={to}" ?? "";
            }
            var result = await m_client.GetAsync <CandlesWrapper, Error> (path);

            return result.Item1.Candles;
        }

        public async Task<IEnumerable<Price>> GetCurrentPrices (string[] instruments)
        {
            if (!instruments.Any())
                throw new ArgumentException("no instrument, plis dont od that. dyslectic btw");
            
            var path = $"accounts/{Constants.AccountId}/pricing";

            path += $"?instruments=";
            foreach (var instrument in instruments)
            {
                path += $"{instrument}," ?? "";
            }
            
            var result = await m_client.GetAsync <PriceWrapper, Error> (path);

            return result.Item1.Prices;
        }
    }
}