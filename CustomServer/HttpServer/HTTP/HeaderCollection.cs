using System.Collections;

namespace HttpServer.HTTP
{
    public class HeaderCollection : IEnumerable<HttpHeader>
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public IReadOnlyDictionary<string, HttpHeader> Headers => this.headers;

        public void AddHeader(HttpHeader header)
        {
            if (this.headers.ContainsKey(header.Name))
            {
                throw new ArgumentException("There are more that one headers with the same name.");
            }

            this.headers.Add(header.Name, header);
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
