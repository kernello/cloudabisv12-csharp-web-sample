using CloudABISSampleWebApp.Models.MatchingServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models
{
    public class CommonAttributes
    {
        public int Position { get; set; }
        public string Status { get; set; }
        public string FeatureDetails { get; set; }
        public EnumOperationName OperationName { get; set; }
    }
}
