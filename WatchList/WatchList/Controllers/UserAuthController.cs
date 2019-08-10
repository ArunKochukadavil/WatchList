using System;
using System.Web.Http;
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
                return Ok(UserAuthBiz.VerifyUser(userAuthData));
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
