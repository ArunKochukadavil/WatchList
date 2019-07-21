using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WatchListDTOs;

namespace WatchListDataLayer.Repo
{
    public class WatchDataRepo
    {
        SqlConnection con;
        SqlCommand cmd;
        Result result;
        string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public WatchDataRepo()
        {
            con = new SqlConnection(conString);
            cmd = new SqlCommand();
            result = new Result();
        }
        public Result AddWatchListData(WatchData data)
        {
            try
            {
                cmd.Parameters.Add("@uid", SqlDbType.VarChar).Value = data.UID;
                cmd.Parameters.Add("@name", SqlDbType.Text).Value = data.Name;
                cmd.Parameters.Add("@genre", SqlDbType.VarChar).Value = data.Genre;
                cmd.Parameters.Add("@season", SqlDbType.TinyInt).Value = data.Season;
                cmd.Parameters.Add("@totalEpisodes", SqlDbType.Int).Value = data.TotalEpisode;
                cmd.Parameters.Add("@episodesCompleted", SqlDbType.Int).Value = data.EpisodesCompleted;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = data.Status;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddOrUpdateWatchList";
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    result.IsSucceed = true;
                    return result;
                }
                else
                {
                    result.IsSucceed = false;
                    result.Messages = new List<string>() { "Reason unknown" };
                    return result;
                }
            }
            finally
            {
                con.Close();
            }
        }
    }
}