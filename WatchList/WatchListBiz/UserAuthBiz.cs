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
                    Messages = new List<string> { jwtToken }
                };
            }
            return new Result<string>() {
                IsSucceed = false,
                Messages = new List<string> { "Invalid Credentials" }
            };
        }

        #region jwttoken

        private static string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742" +
            "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        //private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";


        private static string GenerateJWTUserAuthData(UserAuthData userAuthData)
        {
            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256Signature
            );

            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //PayLoad that contain authentication data

            var payload = new JwtPayload
            {
                {Constants.JWTTokenKey.UserID, userAuthData.UID},
            };

            var secToken = new JwtSecurityToken(header,payload);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(handler.WriteToken(secToken));
            return handler.WriteToken(secToken);
        }

        private static string DecryptJWT()
        {
            return "";
        }
        #endregion
    }
}
