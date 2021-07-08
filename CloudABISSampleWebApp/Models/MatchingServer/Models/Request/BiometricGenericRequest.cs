using System.ComponentModel.DataAnnotations;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models.Request
{
    /// <summary>
    /// Register/Update/Verify API Request Model
    /// </summary>
    public class BiometricGenericRequest
    {
        /// <summary>
        /// Client-specific key provided by the vendor.
        /// </summary>
        [Required(ErrorMessage = "Client Key Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (6) and at most (50) characters long.", MinimumLength = 6)]
        public string ClientKey { get; set; }
        /// <summary>
        /// This is will help you to trace your request full-cycle later. You can put on the request body or the server will be generated and returns with the API response.
        /// </summary>
        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "The {0} must be at least (4) and at most (32) characters long.", MinimumLength = 4)]
        public string SequenceNo { get; set; }
        /// <summary>
        /// The unique identifier (Member ID) of the biometric enrollment that the requested operation will be performed on.
        /// </summary>
        public string RegistrationID { get; set; }
        /// <summary>
        /// The biometric images with supported engine's images. 
        /// The images data should be a base64 encoded string of the original face/fingerprint/iris image.
        /// The number of face images might be 1 to 3. When use only one image, use the Position=1.
        /// The number of finger print images might be 1 to 10. The images position would be 1-10.
        /// The number of iris images might be 1 to 2. The images position would be 1, 2.
        /// Supported image formats: JPG, BMP, PNG, WSQ
        /// </summary>
        [DataType(DataType.Text)]
        //[Required(ErrorMessage = "Images Is Required")]
        public BiometricImages Images { get; set; } = null;
    }
}
