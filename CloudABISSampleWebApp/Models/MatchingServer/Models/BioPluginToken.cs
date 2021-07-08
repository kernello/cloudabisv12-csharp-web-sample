using CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    /// <summary>
    /// UCS token model
    /// </summary>
    public class BioPluginToken : IBioPluginToken
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Expires in seconds
        /// </summary>
        public double ExpiresIn { get; set; }
        /// <summary>
        /// Token type
        /// </summary>
        public string TokenType { get; set; }
        /// <summary>
        /// Error while generating/validating token
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// Error description if there any error occurred while generating/validating token
        /// </summary>
        public string ErrorDescription { get; set; }
    }
}
