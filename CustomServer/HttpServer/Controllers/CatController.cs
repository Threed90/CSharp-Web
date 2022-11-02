using HttpServer.HTTP;
using HttpServer.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Controllers
{
    public class CatController : BaseController
    {
        public CatController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse Index()
        {
            if (Request.Query != null && this.Request.Query.ContainsKey("name"))
            {
                return Html($"<h1>Hello, I am {Request.Query["name"]} cat.</h1><br><h2>Created by Threed</h2>");
            }
            else
            {
                return Html($"<h1>Hello, I am just a random cat!!!</h1><br><h2>Created by Threed</h2>");
            }
        }
    }
}
