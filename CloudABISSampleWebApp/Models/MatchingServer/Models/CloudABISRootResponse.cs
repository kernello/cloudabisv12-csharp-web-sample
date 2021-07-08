using CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces;
using CloudABISSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{

    public class CloudABISRootResponse<T> : ICloudABISRootResponse<T>
    {
        public CloudABISRootResponse()
        {
            Status = AbisConstants.FAILED;
            Message = string.Empty;
            ResponseCode = string.Empty;
            NumOfItemCount = 0;
        }
        /// <summary>
        /// This generic object contains response data
        /// </summary>
        public T ResponseData { get; set; }

        /// <summary>
        /// Request status. The value will be Success/Failed. If this value is Success that means the request has success otherwise you should check message and response code to get the proper information regarding a request.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Contains request success/failed message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// This value contains CloudABIS response code.
        /// </summary>
        public string ResponseCode { get; set; }
        /// <summary>
        /// Will be contain total count of a request
        /// </summary>
        public int NumOfItemCount { get; set; }
    }
}