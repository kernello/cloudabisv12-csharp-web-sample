using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models
{
    public class IrisAttributes : CommonAttributes
    {
        public byte Quality { get; set; }
        public int Sharpness { get; set; }
    }
}
