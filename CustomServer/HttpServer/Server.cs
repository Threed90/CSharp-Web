namespace HttpServer
{
    using Globals;

    using System.Text;

    using System.Net;
    using System.Net.Sockets;
    using HttpServer.HTTP;
    using System.Runtime.CompilerServices;
    using HttpServer.Responces.Contracts;
    using System.Net.Http.Headers;
    using HttpServer.Routing;
    using System.Net.Http;

    public class Server
    {
        private readonly int port;
        private readonly IPAddress address;
        private readonly TcpListener listener;
        private HttpRequest httpRequest;
        private readonly IRoutingMapper mapper;

        public Server(string ip, int port, Action<IRoutingMapper> mapperAction)
        {
            this.port = port;
            this.address = IPAddress.Parse(ip);
            this.listener = new(this.address, port);

            mapperAction(this.mapper = new RoutingMapper());
        }

        public Server(int port, Action<IRoutingMapper> mapperAction)
            : this("127.0.0.1", port, mapperAction)
        {

        }
        public Server(Action<IRoutingMapper> mapperAction)
            : this("127.0.0.1", 9090, mapperAction)
        {

        }

        public async Task StartAsync()
        {
            listener.Start();
            Console.WriteLine($"Server is starting on port {this.port}...");
            Console.WriteLine(new String('=', 100));

            while (true)
            {
                var tcpClient = await this.listener.AcceptTcpClientAsync();

                var networkStream = tcpClient.GetStream();

                string requestContext = await ReadRequestAsync(networkStream);

                //if (string.IsNullOrWhiteSpace(requestContext))
                //{
                //    await WriteResponceAsync(networkStream);
                //    networkStream.Dispose();
                //    tcpClient.Dispose();
                //    continue;
                //}
                this.httpRequest = new HttpRequest();
                await this.httpRequest.SetRequestElements(requestContext);

                if (this.httpRequest.IsFavIcon())
                {
                    networkStream.Dispose();
                    tcpClient.Dispose();
                    continue;
                }

                await WriteResponceAsync(networkStream);

                //networkStream.Flush();
                networkStream.Dispose();
                tcpClient.Dispose();

            }

            
        }

        private async Task WriteResponceAsync(NetworkStream networkStream)
        {
            string responce = this.mapper.GetResponse(this.httpRequest).ToString();

            byte[] responceBytes = Encoding.UTF8.GetBytes(responce);

            await networkStream.WriteAsync(responceBytes);
        }

        private async Task<string> ReadRequestAsync(NetworkStream networkStream)
        {
            byte[] buffer = new byte[1024];

            StringBuilder sb = new StringBuilder();

            int bytesCounter = 0;
            do
            {
                int bytes = await networkStream.ReadAsync(buffer, 0, buffer.Length);

                if (bytesCounter == 10 * 1024)
                {
                    networkStream.Close();
                    throw new InvalidOperationException("The request is too big...");
                }

                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytes));

            } while (networkStream.DataAvailable);

            return sb.ToString();
        }
    }
}
