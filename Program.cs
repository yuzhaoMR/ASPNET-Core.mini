using System.Threading.Tasks;
using App.Server;
using App.WebHost;

namespace App
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateWebHostBuilder()
                .Build()
                .Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseHttpListener()
                .Configure(app => app
                    .Use(Middleware.Middleware.FooMiddleware)
                    .Use(Middleware.Middleware.BarMiddleware)
                    .Use(Middleware.Middleware.BazMiddleware));
        }
    }
}