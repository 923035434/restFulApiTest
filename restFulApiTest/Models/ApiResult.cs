using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulApiTest.Models
{
    public class ApiResult
    {
        public int Code { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}