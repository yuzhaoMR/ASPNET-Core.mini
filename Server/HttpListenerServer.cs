using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.HttpContext;
using App.Middleware;
using App.WebHost;

namespace App.Server
{
    public class HttpListenerServer : IServer
    {
        private readonly HttpListener _httpListener;
        private readonly string[] _urls;

        public HttpListenerServer(params string[] urls)
        {
            _httpListener = new HttpListener();
            _urls = urls.Any() ? urls : new[] {"http://localhost:5000/"};
        }

        public async Task RunAsync(RequestDelegate handler)
        {
            Array.ForEach(_urls, url => _httpListener.Prefixes.Add(url));
            
            if (!_httpListener.IsListening)
            {
                _httpListener.Start();
            }

            Console.WriteLine("Server started and is listening on: {0}", string.Join(';', _urls));

            while (true)
            {
                var listenerContext = await _httpListener.GetContextAsync();
                var feature = new HttpListenerFeature(listenerContext);
                var features = new FeatureCollection()
                    .Set<IHttpRequestFeature>(feature)
                    .Set<IHttpResponseFeature>(feature);
                var httpContext = new HttpContext.HttpContext(features);
                
                await handler(httpContext);
                
                listenerContext.Response.Close();
            }
        }
    }

    public static class Extensions
    {
        public static IWebHostBuilder UseHttpListener(this IWebHostBuilder builder, params string[] urls)
            => builder.UseServer(new HttpListenerServer(urls));
    }
}