using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WatchListDTOs;

namespace WatchListDataLayer.Repository
{
    public class UserAuthDataRepo
    {
        static string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        SqlConnection connection;
        SqlCommand cmd;
        public UserAuthDataRepo()
        {
            connection = new SqlConnection(conString);
            cmd = new SqlCommand();
        }

        /// <summary>
        /// This method is to check whether the credentials provided are true
        /// </summary>
        /// <param name="userAuthData">a object containing User-id and Pass</param>
        /// <returns></returns>
        public Result VerifyCredentials(UserAuthData userAuthData)
        {
            try
            {
                cmd.Parameters.Add("@uid", SqlDbType.NVarChar).Value = userAuthData.UID;
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = userAuthData.Password;
                cmd.CommandText = "GetAuthData";
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    data.Close();
                    return new Result()
                    {
                        IsSucceed = true
                    };
                }
                data.Close();
                return new Result()
                {
                    IsSucceed = false
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
