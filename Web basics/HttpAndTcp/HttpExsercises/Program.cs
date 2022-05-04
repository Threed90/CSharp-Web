using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetHTMLviaHttp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient http = new HttpClient();

            string url = "https://dev.bg/";
            var responce = await http.GetAsync(url);

            string result = await responce.Content.ReadAsStringAsync();

            Console.WriteLine(result);
        }
    }
}
