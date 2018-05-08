using Newtonsoft.Json;

namespace OandaTest.Entity
{
    public class Error
    {
        [JsonProperty ("errorMessage")]
        public string Message;
    }
}