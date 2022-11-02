using HttpServer.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Index()
            => Html("<h1>Simple page for Custom Server</h1><br><h2>Created by Threed</h2>");

        public HttpResponse RedirectToSoftUni()
            => RedirectTo("https://softuni.bg/");
    }
}
