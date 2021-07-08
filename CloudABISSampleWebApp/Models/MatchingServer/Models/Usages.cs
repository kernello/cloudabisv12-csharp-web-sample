using CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    public class Usages: IUsages
    {
        public int LicenseRecords { get; set; }
        public int EnrolledRecords { get; set; }
        public bool AllowFace { get; set; }
        public bool AllowIris { get; set; }
        public bool AllowFingerPrint { get; set; }
        public string OperationResult { get; set; }
    }
}
