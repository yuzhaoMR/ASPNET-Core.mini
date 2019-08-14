using System.Threading.Tasks;
using App.Middleware;
using App.Server;

namespace App.WebHost
{
    public interface IWebHost
    {
        Task Run();
    }

    public class WebHost : IWebHost
    {
        private readonly IServer _server;
        private readonly RequestDelegate _handler;

        public WebHost(IServer server, RequestDelegate handler)
        {
            _server = server;
            _handler = handler;
        }

        public Task Run() => _server.RunAsync(_handler);
    }
}