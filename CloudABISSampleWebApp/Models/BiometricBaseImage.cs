using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models
{
    public abstract class BiometricBaseImage
    {
        public int Position { get; set; }
        public string Base64Image { get; set; }
    }
}
