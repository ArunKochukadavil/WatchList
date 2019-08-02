using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListDataLayer
{
    public static class Constants
    {
        public static class WatchData
        {
            public static readonly string ID = "id";
            public static readonly string UID = "uid";
            public static readonly string Name = "Name";
            public static readonly string Genre = "Genre";
            public static readonly string Season = "Season";
            public static readonly string TotalEpisodes = "TotalEpisodes";
            public static readonly string EpisodesCompleted = "EpisodesCompleted";
            public static readonly string Status = "Status";
            public static readonly string CreationTime = "CreationTime";
            public static readonly string ModificationTime = "ModificationTime";
        } 

        public static class UserAuthData
        {
            public static string UID = "uid";
            public static string Password = "password";
            public static string CreationTime = "creationTime";
            public static string ModifiedTime = "modifiedTime";
            public static string LastLoginTime = "lastLoginTime";
            public static string IsLoggedIn = "isLoggedIn";
            public static string IsAllowed = "IsAllowed";
        }
    }                             
}
