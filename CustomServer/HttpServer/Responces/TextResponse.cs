namespace HttpServer.Responces
{
    using HTTP;
    public class TextResponse : HttpResponse
    {
        public TextResponse(string context)
            : base(HttpStatusCode.OK, "text/plain", context)
        {
        }
    }
}
