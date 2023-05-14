using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (System.Exception error)
            {

                switch (error)
                {
                    
                    default:
                        break;
                }
            }
        }
    }
}
