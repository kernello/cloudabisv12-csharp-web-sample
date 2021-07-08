using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    public class CloudABISAPICredential
    {
        /// <summary>
        /// Client Key
        /// </summary>
        [Required(ErrorMessage = "Client Key Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (16) and at most (64) characters long.", MinimumLength = 16)]
        public string ClientKey { get; set; }
        /// <summary>
        /// API Key 
        /// </summary>
        [Required(ErrorMessage = "Client API Key Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (32) and at most (64) characters long.", MinimumLength = 32)]
        public string ClientAPIKey { get; set; }
        /// <summary>
        /// UCS Base API URL
        /// </summary>
        [Required(ErrorMessage = "Base API URL Is Required")]
        [DataType(DataType.Text)]
        [StringLength(500, ErrorMessage = "The {0} must be at least (5) and at most (500) characters long.", MinimumLength = 5)]
        public string BaseAPIURL { get; set; }
    }
}