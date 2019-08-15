using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WatchListDTOs;

namespace WatchListBiz
{
    public static class TokenHandler
    {
        /// <summary>
        /// for generating token on the basis of username
        /// </summary>
        /// <param name="userAuthData">user credentials</param>
        /// <returns></returns>
        public static string GenerateJWTUserAuthData(UserAuthData userAuthData)
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

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(handler.WriteToken(secToken));
            return handler.WriteToken(secToken);
        }

        /// <summary>
        /// for decryting the JWT
        /// </summary>
        /// <param name="token">JWT</param>
        /// <param name="uid">a variable for getting decrypted user id</param>
        /// <returns></returns>
        public static bool DecryptJWT(string token, out string uid)
        {
            object tempUID;
            var handler = new JwtSecurityTokenHandler();
            var jwtTokenObj = handler.ReadJwtToken(token);
            if (jwtTokenObj.Payload.TryGetValue(Constants.JWTTokenKey.UserID, out tempUID))
            {
                uid = tempUID.ToString();
                return true;
            }
            uid = tempUID?.ToString();
            return false;
        }

        /// <summary>
        /// private key as we are using symmetric encryption
        /// </summary>
        private static string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742" +
            "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
    }
}
