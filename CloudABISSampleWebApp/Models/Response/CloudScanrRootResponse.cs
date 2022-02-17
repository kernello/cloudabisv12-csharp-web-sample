using CloudABISSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Models.Response
{
    public class CloudScanrResponse
    {
        public CloudScanrResponse()
        {
            Success = AbisConstants.FAILED;
            Message = string.Empty;
            ResponseCode = string.Empty;
            NumOfItemCount = 0;
        }

        /// <summary>
        /// Contain CloudScanr API version
        /// </summary>
        public string CloudScanrAPIVersion { get; set; }
        /// <summary>
        /// Request status. The value will be Success/Failed. If this value is Success that means the request has success otherwise you should check message and response code to get the proper information regarding a request.
        /// </summary>
        public string Success { get; set; }
        /// <summary>
        /// Contains request success/failed message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// This value contains CloudScanr response code.
        /// </summary>
        public string ResponseCode { get; set; }
        /// <summary>
        /// Will be contain total count of a request
        /// </summary>
        public int NumOfItemCount { get; set; }
        /// <summary>
        /// Request elapsed time in seconds
        /// </summary>
        public double ElapsedTimeInSeconds { get; set; }
    }
}