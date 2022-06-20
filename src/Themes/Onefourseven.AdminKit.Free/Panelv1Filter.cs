using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Onefourseven.AdminKit.Free {
    /// <summary>
    /// Intercepts any request to check whether it applies to the admin site.
    /// If so it marks the request as such and ensures the user as the right to access it.
    /// </summary>
    public class Panelv1Filter : ActionFilterAttribute {
        private readonly IAuthorizationService _authorizationService;

        public Panelv1Filter(IAuthorizationService authorizationService) {
            _authorizationService = authorizationService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }

            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            object[] actionAttributes = null;
            if (controllerActionDescriptor != null) {
                actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true);
            }

            if (!context.HttpContext.User.Identity.IsAuthenticated && actionAttributes != null && !actionAttributes.Any(x => x is AllowAnonymousAttribute)) {
                context.Result = new ChallengeResult();
                return;
            }

            // var authorized = await _authorizationService.AuthorizeAsync(context.HttpContext.User, Permissions.AccessDashboard);

            // if (!authorized)
            // {
            //     context.Result = new ChallengeResult();
            //     return;
            // }


            await base.OnActionExecutionAsync(context, next);
        }
    }
}
