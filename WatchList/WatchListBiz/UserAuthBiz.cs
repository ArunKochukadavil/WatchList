using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using WatchListDataLayer.Repository;
using WatchListDTOs;

namespace WatchListBiz
{
    public class UserAuthBiz
    {
        /// <summary>
        /// for verifying user and generating token if authentic user
        /// </summary>
        /// <param name="userAuthData">user credentials</param>
        /// <returns></returns>
        public static Result<string> VerifyUser(UserAuthData userAuthData)
        {
            var result = new UserAuthDataRepo().VerifyCredentials(userAuthData);
            if (result.IsSucceed)
            {
                //TODO Generate JWT string
                var jwtToken = TokenHandler.GenerateJWTUserAuthData(userAuthData);
                return new Result<string>()
                {
                    IsSucceed = true,
                    Messages = new List<string> { jwtToken }
                };
            }
            return new Result<string>() {
                IsSucceed = false,
                Messages = new List<string> { "Invalid Credentials" }
            };
        }

        public static Result CreateUser(UserAuthData userAuthData)
        {
            return new UserAuthDataRepo().AddUser(userAuthData);
        }
    }
}
