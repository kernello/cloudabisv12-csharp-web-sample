using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class UsagesRequest
    {
        /// <summary>
        /// Client-specific key provided by the vendor.
        /// </summary>
        [Required(ErrorMessage = "Client Key Is Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least (6) and at most (50) characters long.", MinimumLength = 6)]
        public string ClientKey { get; set; }
    }
}
