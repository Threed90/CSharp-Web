using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _04.SimpleServer
{
    internal class Program
    {
        private static readonly string newLine = "\r\n";
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 12345);
            server.Start();

            while (true)
            {
                var client = server.AcceptTcpClient();
                var stream = client.GetStream();

                byte[] buffer = new byte[256];
                string result = string.Empty;
                int readed = 1;
                while (stream.DataAvailable)
                {
                    readed = stream.Read(buffer, 0, buffer.Length);

                    result += Encoding.UTF8.GetString(buffer);
                }

                Console.WriteLine(result);
                Console.WriteLine(new String('=', 100));
                string html = "<h1> Threed server<h1> <h2>Created for testing purpose<h2>";

                string responce = "HTTP/1.1 200 OK" + newLine +
                                  "Server: ThreedServer 2022" + newLine +
                                  "Content-type: text/html; charset=utf-8" + newLine +
                                  $"Date: {DateTime.UtcNow}" + newLine
                                  + newLine +
                                  html + newLine;

                stream.Write(Encoding.UTF8.GetBytes(responce));

                stream.Flush();
                stream.Close();
                client.Close();
            }

        }
    }
}
