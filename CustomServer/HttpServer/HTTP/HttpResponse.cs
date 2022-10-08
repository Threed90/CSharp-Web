using HttpServer.Globals;
using System.Text;

namespace HttpServer.HTTP
{
    public abstract class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode, string mimeType, string context)
        {
            this.StatusCode = statusCode;
            this.Version = "HTTP/1.1";
            this.Headers = new HeaderCollection();
            this.Headers.AddHeader(new HttpHeader("Date", DateTime.UtcNow.ToString("r")));
            this.Headers.AddHeader(new HttpHeader("Server", Variables.ServerName));
            this.Headers.AddHeader(new HttpHeader("Context-Type", mimeType));
            this.Context = context;
        }
        public string Version { get; private set; } = null!;
        public HttpStatusCode StatusCode { get; private set; }
        public string StatusMessage { get; set; } = null!;

        public HeaderCollection Headers { get; private set; }

        public string Context { get; protected set; } = null!;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Version} {(int)this.StatusCode} {this.StatusCode}{Variables.HttpNewLine}");

            foreach (var header in this.Headers)
            {
                sb.Append($"{header}{Variables.HttpNewLine}");
            }

            sb.Append(Variables.HttpNewLine)
                .Append(this.Context);

            return sb.ToString();

            //       $"Last-Modified: Wed, 22 Jul 2009 19:15:56 GMT{Variables.HttpNewLine}" +
            //       $"Content-Length: 66{Variables.HttpNewLine}" +
            //       $"Content-Type: text/html{Variables.HttpNewLine}" +
            //       Variables.HttpNewLine +
            //       ;
        }
    }
}
