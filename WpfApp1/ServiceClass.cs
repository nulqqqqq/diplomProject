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
        public static async Task<string> PostRequest(string url, T value)
        {
            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.PostAsJsonAsync($"http://localhost:5253/{url}",value);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
        public static async Task<string> GetRequest(string url)
        {
            using (var httpclient = new HttpClient())
            {
                var response = httpclient.GetAsync($"http://localhost:5253/{url}").Result;
                var contents = response.Content.ReadAsStringAsync().Result;
                return contents;
            }
        }
    }
    
}
