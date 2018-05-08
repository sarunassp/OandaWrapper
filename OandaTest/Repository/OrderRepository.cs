using System;
using System.Collections.Generic;
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
            var result = await m_client.GetAsync<OrdersList, Error> ($"{Constants.AccountId}/orders");
            return result.Item1.Orders;
        }
    
        public async Task<T> CreateOrder<T> (T order) where T: OrderRequest
        {
            var result = await m_client.PostAsync <OrderResponse<T>, Error> ($"{Constants.AccountId}/orders", new {order = order});
            return result.Item1.Order;
        }

        public async Task<bool> CancelOrder (string orderId)
        {
            var result = await m_client.PostAsync <object, Error> ($"{Constants.AccountId}/orders/{orderId}/cancel", null);
            if (result.Item1 != null)
                return true;
            
            return false;
        }

        public async Task<Order> GetOrder (string orderId)
        {
            var result = await m_client.GetAsync <OrderWrapper<Order>, Error> ($"{Constants.AccountId}/orders/{orderId}");
            return result.Item1.Order;
        }
    }
}