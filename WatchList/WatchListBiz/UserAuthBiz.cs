using System.Collections.Generic;
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
    }
}
