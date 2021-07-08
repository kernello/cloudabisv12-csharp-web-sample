using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models
{
    public class FingerAttributes : CommonAttributes
    {
        public byte Quality { get; set; }
        public int Nfiq { get; set; }
        public int Nfiq2 { get; set; }
    }
}
