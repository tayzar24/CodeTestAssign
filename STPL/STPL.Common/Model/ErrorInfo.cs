using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Common.Model
{
    public class ErrorInfo
    {
        public string Code { get; set; }
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty(NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<Details> Details { get; set; }
    }

    public class Details
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}
