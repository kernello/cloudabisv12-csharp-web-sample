using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    public class MatchingBadRequestResponse
    {
        public Errors errors { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }
    }
    public class Errors
    {
        public dynamic errors { get; set; }
    }
}