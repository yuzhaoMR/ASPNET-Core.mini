using System.Threading.Tasks;

namespace App.Middleware
{
    public delegate Task RequestDelegate(HttpContext.HttpContext context);
}
