# C# Web
## SoftUni course for Web basics and ASP.NET:

- HTTP basics;
- HTTP understanding;
- HttpClient class usage;
- TCP understanding;
- TcpListener class usage;
- Routing;
- HTTP request and HTTP Response;
- HTTP methods, HTTP version, HTTP URI, HTTP Headers, HTTP Context;


## Custom Server Implementation flow:
- Initial TCP Connection;
- Extend TCP Connection logic;
- Creating HttpRequest and HttpResponse classes;
- Creating HttpMethod enum and HttpStatusCode enum;
- Routing mapper creating and routingTable implementation via Dictionary;
- Extending HttpResponse class as a parent of TextResponse and HtmlResponse;
- Adding action delegate to the IRoutingMapper for easier configuration of routs;
- Adding queryString functionality to the HttpRequest;
- Extending of HttpResponse with request-response func delegate for custom logic implementation of the routing via queryString.
- Adding controllers;
- Creating of extend methods for IRoutingMapper to handle controller with func delegate;
- Creating RedirectResponse and adding BaseController method to use redirections easily.

