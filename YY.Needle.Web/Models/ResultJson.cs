using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YY.Needle.Web.Models
{
    public class ResultJson<T>
    {
        public string ResultCode { get; set; } = "200";
        public T Obj { get; set; }
    }
}