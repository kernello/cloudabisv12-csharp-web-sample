using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces
{
    public interface ICloudABISResponse
    {
        /// <summary>
        /// Request status. The value will be success/failed. If this value is success that means the request has success otherwise you should check message and response code to get the proper information regarding a request.
        /// </summary>
        string Status { get; set; }
        /// <summary>
        /// Contains request success/failed message.
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// This value contains CloudABIS response code.
        /// </summary>
        string ResponseCode { get; set; }
        /// <summary>
        /// Will be contain total count of a request
        /// </summary>
        int NumOfItemCount { get; set; }
    }
}