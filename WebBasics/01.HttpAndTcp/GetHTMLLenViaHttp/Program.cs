using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetHTMLLenViaHttp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            string url = "https://softuni.bg/";

            var responce = await client.GetAsync(url);

            long contentLength = responce.Content.ReadAsStreamAsync().GetAwaiter().GetResult().Length;

            Console.WriteLine(contentLength);
        }
    }
}
