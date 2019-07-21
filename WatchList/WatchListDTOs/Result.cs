using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



