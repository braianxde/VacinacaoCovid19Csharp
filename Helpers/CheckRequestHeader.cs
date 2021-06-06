using Microsoft.AspNetCore.Http;
using ProjetoIntegrador4B.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador4B.Helpers
{
    public class CheckRequestHeader
    {
        private readonly RequestDelegate _next;

        public CheckRequestHeader(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"];
            string url = context.Request.Path;

             string[] pathsGranted = {
                "/api/groupvaccination",
                "/api/login",
                "/api/form",
                "/api/checkrules"
            };

            if (pathsGranted.Contains(url))
            {
                await _next(context);
                return;
            }

            if (token == null || token == "null")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("{\"result\":\"Access denied!\", \"success\":false}");
                return;
            }

            projetointegrador3bContext _context = new projetointegrador3bContext();
            Useradm exists = _context.Useradm.First(f => f.Token == token);

            if (exists.Id != 0)
            {
                await _next(context);
                return;
            }

            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("{\"result\":\"Access denied!\", \"success\":false}");
            return;
        }
    }
}
