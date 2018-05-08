using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OandaTest.Entity;
using OandaTest.Entity.Order;
using OandaTest.Entity.OrderRequest;
using OandaTest.Repository;

namespace OandaTest
{
    internal class Program
    {
        private static readonly OrderRepository repo = new OrderRepository ();
        
        public static void Main (string[] args)
        {
//            var resultCreated = TestCreate ().GetAwaiter ().GetResult ();
//            var resultOrders = TestGetOrders ().GetAwaiter ().GetResult ();
//            var resultCancel = TestCancel (resultCreated.Id).GetAwaiter ().GetResult ();
//            resultOrders = TestGetOrders ().GetAwaiter ().GetResult ();
//            var resultGetorderCancelled = TestGetOrder (resultCreated.Id).GetAwaiter ().GetResult ();
            
//            var resultBought = TestCreateWillBuy ().GetAwaiter ().GetResult ();
//            var resultGetOrder = TestGetOrder (resultBought.Id).GetAwaiter ().GetResult ();

            var asd = JsonConvert.SerializeObject (new PriceWrapper ()
            {
                Prices = new List<Price>
                {
                    new Price ()
                    {
                        Asks = new List<PriceQuotation> (),
                        Bids = new List<PriceQuotation> ()
                    }
                }
            });
            
            var resultCandles = TestGetCandles (InstrumentName.EurCad).GetAwaiter ().GetResult ();

            var instruments = new string[] {InstrumentName.EurCad, InstrumentName.EurUsd};
            var resultPrices = TestGetCurrentPrices (instruments).GetAwaiter ().GetResult ();
            
            var asd4 = "";
        }
        
        public static async Task<LimitOrderRequest> TestCreate ()
        {
            var order = new LimitOrderRequest
            (
                InstrumentName.EurUsd,
                5,
                new decimal(0.5),
                DateTime.Today + new TimeSpan(1, 0, 0)
            );
            return await repo.CreateOrder (order);
        }

        public static async Task<IEnumerable<Order>> TestGetOrders ()
        {
            return await repo.GetOrders ();
        }

        public static async Task<bool> TestCancel (string orderId)
        {
            return await repo.CancelOrder (orderId);
        }
        
        public static async Task<LimitOrderRequest> TestCreateWillBuy ()
        {
            var order = new LimitOrderRequest
            (
                InstrumentName.EurUsd,
                5,
                new decimal(2),
                DateTime.Today + new TimeSpan(1, 0, 0)
            );
            return await repo.CreateOrder (order);
        }

        public static async Task<Order> TestGetOrder (string orderId)
        {
            return await repo.GetOrder (orderId);
        }

        public static async Task<IEnumerable<Candle>> TestGetCandles (string instrument)
        {
            return await repo.GetPrices (instrument);
        }
        
        public static async Task<IEnumerable<Price>> TestGetCurrentPrices (string[] instruments)
        {
            return await repo.GetCurrentPrices (instruments);
        }
    }
}