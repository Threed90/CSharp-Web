using HttpServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Responces
{
    public class HtmlResponse : HttpResponse
    {
        public HtmlResponse(string context) 
            : base(HttpStatusCode.OK, "text/html", context)
        {
        }
    }
}
