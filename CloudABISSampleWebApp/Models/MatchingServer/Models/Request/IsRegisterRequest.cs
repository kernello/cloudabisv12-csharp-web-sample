using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models.Request
{
    /// <summary>
    /// Is Register API Request Model
    /// </summary>
    public class IsRegisterRequest
    {
        /// <summary>
        /// Client-specific key provided by the vendor.
        /// </summary>
        [Required(ErrorMessage = "Client Key Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (6) and at most (50) characters long.", MinimumLength = 6)]
        public string ClientKey { get; set; }
        /// <summary>
        /// This will help you to trace your request full-cycle later. You can put on the request body or the server will be generated and returns with the API response.
        /// </summary>
        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "The {0} must be at least (4) and at most (32) characters long.", MinimumLength = 4)]
        public string SequenceNo { get; set; }
        /// <summary>
        /// The unique identifier (Member ID) of the biometric enrollment that the requested operation will be performed on.
        /// </summary>
        [Required(ErrorMessage = "Registration Id Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (4) and at most (50) characters long.", MinimumLength = 4)]
        public string RegistrationID { get; set; }
        

    }
}
