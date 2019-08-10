using System.Web.Http;
using System.Web.Http.Controllers;

namespace WatchList.AuthHandler
{
    public class UserAuthCheck : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var httpRequestHeader = actionContext.Request.Headers.GetValues("Authorization");
            return true;
        }
    }
}