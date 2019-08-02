using System;
using System.Web.Http;
using WatchListBiz;
using WatchListDTOs;

namespace WatchList.Controllers
{
    [RoutePrefix("WatchData")]
    public class WatchDataController : ApiController
    {
        [Route("Get")]
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
