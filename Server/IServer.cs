using System.Threading.Tasks;
using App.Middleware;

namespace App.Server
{
    public interface IServer
    {
        Task RunAsync(RequestDelegate handler);
    }
}