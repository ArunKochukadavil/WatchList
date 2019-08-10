using System;
using System.Web.Http;
using WatchList.AuthHandler;
using WatchListBiz;
using WatchListDTOs;

namespace WatchList.Controllers
{
    [RoutePrefix("WatchData")]
    public class WatchDataController : ApiController
    {
        /// <summary>
        /// for getting watch list data for the specified user
        /// </summary>
        /// <param name="uid">UserID</param>
        /// <returns></returns>
        [Route("Get")]
        [UserAuthCheck]
        [HttpGet]
        public IHttpActionResult GetWatchData(string uid)
        {
            try
            {
                return Ok(WatchData.GetWatchData(uid));
            }
            catch(Exception ex)
            {
                return Ok(new Result(){
                    IsSucceed=false,
                    Exception = ex
                });
            }
        }
    }
}
