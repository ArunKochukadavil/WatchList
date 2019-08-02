using System;
using System.Collections.Generic;

namespace WatchListDTOs
{
    public class Result
    {
        public bool IsSucceed { get; set; }
        public List<string> Messages { get; set; }
        public Exception Exception { get; set; }
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}



