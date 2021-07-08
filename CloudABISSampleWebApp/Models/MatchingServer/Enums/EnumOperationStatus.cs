using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Enums
{
    /// <summary>
    /// Operation Status
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumOperationStatus
    {
        NONE = 0,
        /// <summary>
        /// If operation success
        /// </summary>
        SUCCESS = 1,
        /// <summary>
        /// Opeartion failed
        /// </summary>
        FAILED = 2,
        /// <summary>
        /// Invalid access. It could be client not found
        /// </summary>
        INVALID_ACCESS = 3,
        /// <summary>
        /// License error
        /// </summary>
        LICENSE_ERROR = 4,
        /// <summary>
        /// Engine exception
        /// </summary>
        ENGINE_EXCEPTION = 5,
        /// <summary>
        /// Bad request. It could be some required data not found/mitch match
        /// </summary>
        BAD_REQUEST = 6,
        /// <summary>
        /// Internal error
        /// </summary>
        INTERNAL_ERROR = 7,
        /// <summary>
        /// Biometric extraction failed
        /// </summary>
        EXTRACTION_FAILED = 8,
        /// <summary>
        /// Internal API error
        /// </summary>
        API_ERROR = 9,
        /// <summary>
        /// Server busy
        /// </summary>
        SERVER_BUSY = 10,
        /// <summary>
        /// Server busy with different reason like 502,503
        /// </summary>
        SERVER_BUSY_UCS500 = 11,
        /// <summary>
        /// Server busy with different reason except 502,503
        /// </summary>
        SERVER_BUSY_UCS5000 = 12,
        /// <summary>
        /// Biometric licnese exceed
        /// </summary>
        LICENSE_EXCEED = 13
    }
}
