using HttpServer.Controllers;
using HttpServer.HTTP;
using HttpServer.Responces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Extensions
{
    public static class RoutingMapperExtension
    {
        public static IRoutingMapper MapGet<TController>(this IRoutingMapper mapper, string uri, Func<TController, HttpResponse> func)
            where TController : BaseController
            =>
                mapper.MapGet(uri, request =>
                {
                    var controller = (TController)Activator.CreateInstance(typeof(TController), new object[] { request });
    
                    return func(controller);
                });

        public static IRoutingMapper MapPost<TController>(this IRoutingMapper mapper, string uri, Func<TController, HttpResponse> func)
            where TController : BaseController
            =>
                mapper.MapPost(uri, request =>
                {
                    var controller = (TController)Activator.CreateInstance(typeof(TController), new object[] { request });

                    return func(controller);
                });

        public static IRoutingMapper MapMap<TController>(this IRoutingMapper mapper, HttpMethods method, string uri, Func<TController, HttpResponse> func)
            where TController : BaseController
            =>
                mapper.Map(method, uri, request =>
                {
                    var controller = (TController)Activator.CreateInstance(typeof(TController), new object[] { request });

                    return func(controller);
                });
    }
}
