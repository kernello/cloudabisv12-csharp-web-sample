using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models
{
    public class FaceAttributes : CommonAttributes
    {
        public byte Quality { get; set; }
        public byte Sharpness { get; set; }
    }
}
