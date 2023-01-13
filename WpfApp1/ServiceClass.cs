using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ServiceClass<T>
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> PostRequest(string url, T value)
        {
            var response = await client.PostAsync($"https://localhost:7231/{url}", new StringContent(
                    JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json"));
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }
        public static async Task<string> GetRequest(string url)
        {
            var response = client.GetAsync($"https://localhost:7231/{url}").Result;
            var contents = response.Content.ReadAsStringAsync().Result;
            return contents;
        }
    }
    
}
