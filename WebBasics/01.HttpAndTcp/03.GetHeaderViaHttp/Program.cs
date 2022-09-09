using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetHeaderViaHttp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string url = "https://softuni.bg";

            var responce = await client.GetAsync(url);

            //A way to get all headers as whole string (posibility to split to \r\n):
            string allHeaders = responce.Headers.ToString();

            var headers = responce.Headers.Concat(responce.Content.Headers);

            foreach (var item in headers)
            {
                Console.WriteLine(item.Key + ": ");

                foreach (var value in item.Value)
                {
                    Console.WriteLine($"  {value}");
                }
                Console.WriteLine(new String('=', 100));
            }
        }
    }
}
