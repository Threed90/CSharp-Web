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
                    router.MapGet("/", new HtmlResponse("<h1>Simple page for Custom Server</h1><br><h2>Created by Threed</h2>")));

            await server.StartAsync();
        }
    }
}