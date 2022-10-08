using HttpServer.Globals;

namespace HttpServer.HTTP
{
    public class HttpRequest
    {
        public HttpMethods Method { get; private set; }
        public string URI { get; private set; } = null!;
        public string Version { get; private set; } = null!;

        public HeaderCollection Headers { get; private set; } = null!;

        public async Task SetRequestElements(string httpRequest)
        {
            var lines = httpRequest.Split(Variables.HttpNewLine);

            var firstLine = lines.First().Split(" ");
            this.Method = this.GetMethod(firstLine[0]);
            this.URI = firstLine[1];
            this.Version = firstLine[2];

            this.Headers = this.GetHeaders(lines.Skip(1));

        }

        public bool IsFavIcon()
        {
            return this.URI == "/favicon.ico";
        }

        private HttpMethods GetMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpMethods.GET,
                "POST" => HttpMethods.POST,
                "PUT" => HttpMethods.PUT,
                "DELETE" => HttpMethods.DELETE,
                _ => throw new InvalidOperationException($"Server does not support {method} method.")
            };
        }

        private HeaderCollection GetHeaders(IEnumerable<string> headers)
        {
            HeaderCollection headerCollection = new();

            foreach (var header in headers)
            {
                if(header == "")
                {
                    break;
                }
                var headerElements = header.Split(":", 2);
                HttpHeader httpHeader = new(headerElements[0], headerElements[1]);

                headerCollection.AddHeader(httpHeader);
            }

            return headerCollection;
        }
    }
}
