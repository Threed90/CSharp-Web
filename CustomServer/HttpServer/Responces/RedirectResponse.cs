using HttpServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Responces
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location) 
            : base(HttpStatusCode.Found, "text/html", "")
        {
            this.Headers.AddHeader(new HttpHeader("Location", location));
        }
    }
}
