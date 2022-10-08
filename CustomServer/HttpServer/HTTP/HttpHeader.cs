using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.HTTP
{
    public class HttpHeader
    {
        public HttpHeader(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; init; } = null!;
        public string Value { get; init; } = null!;

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}
