using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces
{
    public interface IUsages
    {
        int LicenseRecords { get; set; }
        int EnrolledRecords { get; set; }
        bool AllowFace { get; set; }
        bool AllowIris { get; set; }
        bool AllowFingerPrint { get; set; }
    }
}
