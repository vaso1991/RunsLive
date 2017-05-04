using System.Linq;
using System.Web.Mvc;

namespace RunsLive.Attributes
{
    public class AdminAuthorizeAttribute:AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',');
            if (filterContext.HttpContext.Request.IsAuthenticated && !roles.Any(s=> filterContext.HttpContext.User.IsInRole(s)))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Unauthorized.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
           
        }
    }
}