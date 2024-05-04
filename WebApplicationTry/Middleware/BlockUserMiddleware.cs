using Microsoft.AspNetCore.Identity;
using WebApplicationTry.Models;

namespace WebApplicationTry.Middleware
{
    public class BlockUserMiddleware
    {
        private readonly RequestDelegate _next;

        public BlockUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(context.User);
                if (user != null && user.IsBlocked)
                {
                    context.Response.Redirect("/Account/Logout"); 
                }
            }
            await _next(context);
        }
    }
}
