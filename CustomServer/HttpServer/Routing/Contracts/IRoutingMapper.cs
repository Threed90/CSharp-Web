namespace HttpServer.Responces.Contracts
{
    using HTTP;
    using HttpMethods = HTTP.HttpMethods;
    public interface IRoutingMapper
    {
        IRoutingMapper Map(HttpMethods method, string uri, HttpResponse responce);

        public IRoutingMapper Map(HttpMethods method, string uri, Func<HttpRequest, HttpResponse> func);
        IRoutingMapper MapGet(string uri, HttpResponse responce);

        IRoutingMapper MapGet(string uri, Func<HttpRequest, HttpResponse> func);

        IRoutingMapper MapPost(string uri, HttpResponse responce);

        IRoutingMapper MapPost(string uri, Func<HttpRequest, HttpResponse> func);
        HttpResponse GetResponse(HttpRequest request);
    }
}
