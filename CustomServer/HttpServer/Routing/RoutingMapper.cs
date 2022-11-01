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
        private readonly Dictionary<HttpMethods, Dictionary<string, Func<HttpRequest, HttpResponse>>> routings;

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

        public IRoutingMapper Map(HttpMethods method, string uri, HttpResponse responce)
         => this.Map(method, uri, request => responce);

        public IRoutingMapper Map(HttpMethods method, string uri, Func<HttpRequest, HttpResponse> responce)
        {
            this.routings[method][uri] = responce;

            return this;
        }

        public IRoutingMapper MapGet(string uri, HttpResponse responce)
            => this.MapGet(uri, request => responce);

        public IRoutingMapper MapGet(string uri, Func<HttpRequest, HttpResponse> func)
            => this.Map(HttpMethods.GET, uri, func);

        public IRoutingMapper MapPost(string uri, HttpResponse responce)
            => this.MapPost(uri, request => responce);

        public IRoutingMapper MapPost(string uri, Func<HttpRequest, HttpResponse> func)
            => this.Map(HttpMethods.POST, uri, func);

        public HttpResponse GetResponse(HttpRequest request)
            => this.routings[request.Method][request.URI](request);

    }
}
