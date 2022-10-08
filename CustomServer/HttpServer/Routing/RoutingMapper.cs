using HttpServer.HTTP;
using HttpServer.Responces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Routing
{
    public class RoutingMapper : IRoutingMapper
    {
        private readonly Dictionary<HttpMethods, Dictionary<string, HttpResponse>> routings;

        public RoutingMapper()
        {
            this.routings = new()
            {
                [HttpMethods.GET] = new(),
                [HttpMethods.POST] = new(),
                [HttpMethods.PUT] = new(),
                [HttpMethods.DELETE] = new()
            };
        }

        public IRoutingMapper Map(string uri, HttpMethods method, HttpResponse responce)
        {
            this.routings[method][uri] = responce;

            return this;
        }

        public IRoutingMapper MapGet(string uri, HttpResponse responce)
        {
            this.routings[HttpMethods.GET][uri] = responce;

            return this;
        }

        public HttpResponse GetResponse(HttpRequest request)
        {
            
            return this.routings[request.Method][request.URI];
        }
    }
}
