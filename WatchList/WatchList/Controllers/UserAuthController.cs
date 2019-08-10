using System;
using System.Web.Http;
using WatchList.AuthHandler;
using WatchListBiz;
using WatchListDTOs;

namespace WatchList.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Auth")]
    public class UserAuthController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult UserLogin(UserAuthData userAuthData)
        {
            try
            {
                var result = UserAuthBiz.VerifyUser(userAuthData);
                JWTokenHolder.tokenHolder.Add(result.Messages[0], Constants.JWTTokenKey.LoggedIn);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(new Result()
                {
                    IsSucceed=false,
                    Exception = ex
                });
            }
        }
    }
}
