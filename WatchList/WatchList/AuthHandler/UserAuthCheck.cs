using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http;
using System.Web.Http.Controllers;
using WatchListBiz;

namespace WatchList.AuthHandler
{
    public class UserAuthCheck : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                var httpRequestHeader = actionContext.Request.Headers.Authorization.Parameter.Split()[0];
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(httpRequestHeader);
                object uid;
                if (token.Payload.TryGetValue(Constants.JWTTokenKey.UserID, out uid))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}