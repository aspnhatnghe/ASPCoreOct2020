using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day20_WebAPI.Models
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
