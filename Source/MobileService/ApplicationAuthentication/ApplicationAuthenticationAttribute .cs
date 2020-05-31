namespace MobileService.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ApplicationAuthentication : Attribute, IAsyncActionFilter
    {
        private readonly string[] roles;

        public ApplicationAuthentication(params string[] roles)
        {
            this.roles = roles;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var role = context.HttpContext.User.FindFirstValue(ClaimTypes.Role);

            if (!this.roles.Any(x => x == role))
            {
                context.HttpContext.Response.Redirect("/Home/Index");
                return;
            }

            await next();
        }
    }
}
