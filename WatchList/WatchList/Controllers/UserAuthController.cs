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

        /// <summary>
        /// api for creating user
        /// </summary>
        /// <param name="userAuthData">credentials for new user</param>
        /// <returns></returns>
        [HttpPost]
        [Route("User/Create")]
        public IHttpActionResult CreateUser(UserAuthData userAuthData)
        {
            try
            {
                return Ok(UserAuthBiz.CreateUser(userAuthData));
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY constraint 'PK_UserAuthData'. Cannot insert duplicate key"))
                {
                    return Ok(new Result()
                    {
                        IsSucceed = false,
                        Messages = new System.Collections.Generic.List<string>()
                        {
                            "User already exists"
                        }
                    });
                }
                return Ok(new Result()
                {
                    IsSucceed = false,
                    Exception = ex
                });
            }
        }
    }
}
