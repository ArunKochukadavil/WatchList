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
        /// <summary>
        /// for authentication user and issuing token i.e JWT
        /// </summary>
        /// <param name="userAuthData">user credentials</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult UserLogin(UserAuthData userAuthData)
        {
            try
            {
                var result = UserAuthBiz.VerifyUser(userAuthData);
                if(!JWTokenHolder.tokenHolder.ContainsKey(userAuthData.UID))
                {
                    JWTokenHolder.tokenHolder.Add(userAuthData.UID, Constants.JWTTokenKey.LoggedIn);
                }
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
