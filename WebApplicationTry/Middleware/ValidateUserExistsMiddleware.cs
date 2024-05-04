using Microsoft.AspNetCore.Identity;
using WebApplicationTry.Models;

namespace WebApplicationTry.Middleware
{
    public class ValidateUserExistsMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidateUserExistsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(context.User);
                if (user == null) 
                {
                    if (!context.Request.Path.StartsWithSegments("/Account/Logout"))
                    {
                        context.Response.Redirect("/Account/Logout");
                        return; 
                    }
                }
            }
            await _next(context); 
        }
    }

}
