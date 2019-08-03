using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WatchListDTOs
{
    public class Result
    {
        [JsonProperty(Order = 1)]
        public bool IsSucceed { get; set; }

        [JsonProperty(Order = 2)]
        public List<string> Messages { get; set; }

        [JsonProperty(Order = 3)]
        public Exception Exception { get; set; }
    }
    public class Result<T> : Result
    {
        [JsonProperty(Order = 4)]
        public T Data { get; set; }
    }
}



