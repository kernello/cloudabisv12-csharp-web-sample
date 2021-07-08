using CloudABISSampleWebApp.Models.MatchingServer.Enums;
using CloudABISSampleWebApp.Models.MatchingServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces
{
    /// <summary>
    /// Matching result
    /// </summary>
    public interface IMatchingResult
    {
        /// <summary>
        /// Requester client key
        /// </summary>
        string ClientKey { get; set; }
        /// <summary>
        /// Matching instance id
        /// </summary>
        int InstanceID { get; set; }
        /// <summary>
        /// The unique sequence no which specified request id
        /// </summary>
        string SequenceNo { get; set; }

        /// <summary>
        /// Operation/request name
        /// </summary>
        EnumOperationName OperationName { get; set; }

        /// <summary>
        /// Operation/request status
        /// </summary>
        EnumOperationStatus OperationStatus { get; set; }
        /// <summary>
        /// Operation/Request result
        /// </summary>
        string OperationResult { get; set; }
        /// <summary>
        /// Response details
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// Best result
        /// </summary>
        ResultScore BestResult { get; set; }
        /// <summary>
        /// Matching result details
        /// </summary>
        List<ResultScoreItem> DetailResult { get; set; }
        /// <summary>
        /// Extraction details
        /// </summary>
        ExtractionDetails ExtractionDetailes { get; set; }
        /// <summary>
        /// Request exception message which will be used on alert publish
        /// </summary>
        string ExceptionMessage { get; set; }
        /// <summary>
        /// Request inner message which will be used on alert publish
        /// </summary>
        string StackTrace { get; set; }
    }
}
