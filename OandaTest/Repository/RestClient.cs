using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OandaTest.Entity;

namespace OandaTest.Repository
{
    public class RestClient
    {
        private readonly HttpClient m_client;

        public RestClient ()
        {
            m_client = new HttpClient {BaseAddress = new Uri ("https://api-fxpractice.oanda.com/v3/accounts/")};
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
            (
                "Bearer",
                Constants.ApiToken
            );
        }
        
        public async Task<Tuple<TSuccess, TFail>> GetAsync<TSuccess, TFail> (string path)
        {
            var response = await m_client.GetAsync (path);
            return await ParseResponse<TSuccess, TFail> (response);
        }

        public async Task<Tuple<TSuccess, TFail>> PostAsync<TSuccess, TFail> (string path, object payload)
        {
            var response = await m_client.PostAsync (path, GetStringContent (payload));
            return await ParseResponse<TSuccess, TFail> (response);
        }
        
        public async Task<Tuple<TSuccess, TFail>> PutAsync<TSuccess, TFail> (string path, object payload)
        {
            var response = await m_client.PutAsync (path, GetStringContent (payload));
            return await ParseResponse<TSuccess, TFail> (response);
        }

        private static async Task<Tuple<TSuccess, TFail>> ParseResponse<TSuccess, TFail> (HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync ();
            if (response.IsSuccessStatusCode)
            {
                return new Tuple<TSuccess, TFail> (JsonConvert.DeserializeObject<TSuccess> (responseContent), (TFail)(object)null);
            }
            else
            {
                return new Tuple<TSuccess, TFail> ((TSuccess)(object)null, JsonConvert.DeserializeObject<TFail> (responseContent));
            }
        }
        
        private static StringContent GetStringContent (object content) => new StringContent(JsonConvert.SerializeObject (content), Encoding.UTF8, "application/json");
    }
}