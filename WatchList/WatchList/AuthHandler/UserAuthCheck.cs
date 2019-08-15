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
                var token = actionContext.Request.Headers.Authorization.Parameter.Split()[0];
                string uid;
                return TokenHandler.DecryptJWT(token, out uid);
            }
            catch
            {
                return false;
            }
        }
    }
}