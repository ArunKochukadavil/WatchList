using System.Collections.Generic;
using WatchListDataLayer.Repository;
using WatchListDTOs;

namespace WatchListBiz
{
    public class WatchData
    {
        public static Result<List<WatchDataDTO>> GetWatchData(string uid)
        {
            return new WatchDataRepo().GetWatchData(uid);
        }
    }
}
