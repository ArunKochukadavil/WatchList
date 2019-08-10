using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using WatchListDataLayer.Repository;
using WatchListDTOs;
namespace WatchListBiz
{
    public class UserAuthBiz
    {
        public static Result<string> VerifyUser(UserAuthData userAuthData)
        {
            var result = new UserAuthDataRepo().VerifyCredentials(userAuthData);
            if (result.IsSucceed)
            {
                //TODO Generate JWT string
                var jwtToken = GenerateJWTUserAuthData(userAuthData);
                return new Result<string>()
                {
                    IsSucceed = true,
                    Messages = new List<string> { "JWT string here" }
                };
            }
            return new Result<string>() {
                IsSucceed = false,
                Messages = new List<string> { "Invalid Credentials" }
            };
        }

        HMACSHA256 hmac = new HMACSHA256();
        private static string Secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";


        private static object GenerateJWTUserAuthData(UserAuthData userAuthData)
        {
            //var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            return null;

        }
    }
}
