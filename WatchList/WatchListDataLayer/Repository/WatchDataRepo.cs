using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WatchListDTOs;

namespace WatchListDataLayer.Repository
{
    public class WatchDataRepo
    {
        static string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        SqlConnection connection;
        SqlCommand cmd;
        public WatchDataRepo()
        {
            connection = new SqlConnection(conString);
            cmd = new SqlCommand();
        }

        /// <summary>
        /// to get the Watch List Data of the specific user
        /// </summary>
        /// <param name="uid">User Id of user</param>
        /// <returns>A result object containing status of operation</returns>
        public Result<List<WatchDataDTO>> GetWatchData(string uid)
        {
            try
            {
                var watchDataList = new List<WatchDataDTO>();
                cmd.Parameters.Add("@uid", SqlDbType.NVarChar).Value = uid;
                cmd.CommandText = "GetWatchData";
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    watchDataList.Add(new WatchDataDTO()
                    {
                        ID = data.GetInt32(data.GetOrdinal(Constants.WatchData.ID)),
                        Name = data.GetString(data.GetOrdinal(Constants.WatchData.Name)),
                        Genre = data.GetString(data.GetOrdinal(Constants.WatchData.Genre)),
                        Season = data.GetByte(data.GetOrdinal(Constants.WatchData.Season)),
                        TotalEpisodes = data.GetInt32(data.GetOrdinal(Constants.WatchData.TotalEpisodes)),
                        EpisodesCompleted = data.GetInt32(data.GetOrdinal(Constants.WatchData.EpisodesCompleted)),
                        Status = data.GetString(data.GetOrdinal(Constants.WatchData.Status)),
                        Reviews = data.GetByte(data.GetOrdinal(Constants.WatchData.Reviews)),
                        Description = data.GetString(data.GetOrdinal(Constants.WatchData.Description)),
                        DownloadLinks = data.GetString(data.GetOrdinal(Constants.WatchData.DownloadLinks))
                    });
                }
                data.Close();
                return new Result<List<WatchDataDTO>>()
                {
                    IsSucceed = true,
                    Data = watchDataList
                };
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }
    }
}
