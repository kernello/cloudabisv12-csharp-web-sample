using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BiometricImages
    {
        /// <summary>
        /// Captured fingerprint iamges as a wsq format. (Images data itself is Base64 encoded.). This fields containts only FingerPrint images.
        /// </summary>
        public List<FingerImage> Fingerprint { get; set; }
        /// <summary>
        /// Captured iris iamges as a wsq format. (Images data itself is Base64 encoded.). This fields containts only Iris images.
        /// </summary>
        public List<IrisImage> Iris { get; set; }
        /// <summary>
        /// Captured face image data. (Face image data itself is Base64 encoded.). Default face image format is JPEG
        /// </summary>
        public List<FaceImage> Face { get; set; }
    }
}
