using HttpServer.Controllers;
using HttpServer.Extensions;
using HttpServer.Responces;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace HttpServer
{
    public class StartUp
    {
        static async Task  Main(string[] args)
        {
            var server = new Server(
                router =>
                    router.MapGet<HomeController>("/", c => c.Index())
                        .MapGet<CatController>("/Cat", c => c.Index())
                        .MapGet<HomeController>("/SoftUni", c => c.RedirectToSoftUni()));

            await server.StartAsync();
        }
    }
}