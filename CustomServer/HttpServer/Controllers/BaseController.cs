using HttpServer.HTTP;
using HttpServer.Responces;
using HttpServer.Responces.Contracts;

namespace HttpServer.Controllers
{
    public abstract class BaseController
    {
        protected BaseController(HttpRequest request)
            => this.Request = request;

        protected HttpRequest Request { get; init; }

        protected HttpResponse Text(string context)
            => new TextResponse(context);

        protected HttpResponse Html(string context)
            => new HtmlResponse(context);

        protected HttpResponse RedirectTo(string location)
            => new RedirectResponse(location);
    }
}
