using CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models.Request
{
    /// <summary>
    /// Change Id API Request Model
    /// </summary>
    public class ChangeIdRequest : IValidatableObject
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
        [Required(ErrorMessage = "RegistrationId Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (4) and at most (50) characters long.", MinimumLength = 4)]
        public string RegistrationId { get; set; }
        /// <summary>
        /// The new unique identifier (Member ID) that the existing ID will be changed to.
        /// </summary>
        [Required(ErrorMessage = "NewRegistrationId Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (4) and at most (50) characters long.", MinimumLength = 4)]
        public string NewRegistrationId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RegistrationId.Equals(NewRegistrationId))
            {
                yield return new ValidationResult("RegistrationId & NewRegistrationId should not be same.", new[] { "RegistrationId", "NewRegistrationId" });
            }
        }
       
    }
}
