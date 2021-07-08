using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBioPluginToken
    {
        /// <summary>
        /// Access token
        /// </summary>
        string AccessToken { get; set; }
        /// <summary>
        /// Expires in seconds
        /// </summary>
        double ExpiresIn { get; set; }
        /// <summary>
        /// Token type
        /// </summary>
        string TokenType { get; set; }
        /// <summary>
        /// Error while generating/validating token
        /// </summary>
        string Error { get; set; }
        /// <summary>
        /// Error description if there any error occurred while generating/validating token
        /// </summary>
        string ErrorDescription { get; set; }
    }
}
