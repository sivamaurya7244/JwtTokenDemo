/*using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Reflection;

public class UserContextActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = context.HttpContext.User;

        // Claims from JWT
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = user.FindFirst(ClaimTypes.Role)?.Value;
        var clientIdClaim = user.FindFirst("clientid")?.Value;

        foreach (var arg in context.ActionArguments.Values)
        {
            if (arg == null) 
                continue;

            var type = arg.GetType();

            // =========================================
            // 1. Set LoggedInUserId
            // =========================================
            var userIdProp = type.GetProperty("LoggedInUserId", BindingFlags.Public | BindingFlags.Instance);

            if (userIdProp != null &&
                userIdProp.CanWrite &&
                userIdProp.PropertyType == typeof(int) &&
                !string.IsNullOrWhiteSpace(userIdClaim))
            {
                userIdProp.SetValue(arg, Convert.ToInt32(userIdClaim));
            }

            // =========================================
            // 2. Set ClientIds for clientuser/superwiser
            //    Only single clientid from token
            // =========================================
            var clientIdsProp = type.GetProperty("ClientIds", BindingFlags.Public | BindingFlags.Instance);

            if (clientIdsProp is { CanWrite: true } && clientIdClaim is { Length: > 0 } && role is "clientuser" or "superwiser")
			{
				clientIdsProp.SetValue(arg, new List<int> { Convert.ToInt32(clientIdClaim) });
			}
        }
    }
}*/
