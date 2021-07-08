using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models
{
    public class ExtractionDetails
    {
        public List<FaceAttributes> Faces { get; set; }
        public List<FingerAttributes> Fingers { get; set; }
        public List<IrisAttributes> Irises { get; set; }
    }
}
