using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Adapter
{
    public class MonoovaHelper
    {
        private readonly HttpClient _client;
        private static MonoovaHelper _monoovaHelper = null;
        private static readonly object Padlock = new object();

        public MonoovaHelper()
        {
            _client = new HttpClient {BaseAddress = new Uri("https://api.m-pay.com.au")};
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("b0060869-63b4-4113-8db7-fff9aa328340:");
            var apiKey = Convert.ToBase64String(plainTextBytes);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", apiKey);
        }
        
        public static MonoovaHelper Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _monoovaHelper ??= new MonoovaHelper();
                }
            }
        }

        public HttpClient GetClient()
        {
            return _client;
        }
    }
}