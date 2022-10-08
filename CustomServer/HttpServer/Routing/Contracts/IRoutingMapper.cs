namespace HttpServer.Responces.Contracts
{
    using HTTP;
    using HttpMethods = HTTP.HttpMethods;
    public interface IRoutingMapper
    {
        IRoutingMapper Map(string uri, HttpMethods method, HttpResponse responce);
        IRoutingMapper MapGet(string uri, HttpResponse responce);
        HttpResponse GetResponse(HttpRequest request);
    }
}
