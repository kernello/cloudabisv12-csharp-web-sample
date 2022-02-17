using CloudABISSampleWebApp.Models.MatchingServer.Enums;
using CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    /// <summary>
    /// Match result
    /// </summary>
    public class MatchingResult : MatchingBadRequestResponse, IMatchingResult
    {
        /// <summary>
        /// Matching instance id
        /// </summary>
        public int InstanceID { get; set; }
        /// <summary>
        /// The unique sequence no which specified request id
        /// </summary>
        public string SequenceNo { get; set; }

        /// <summary>
        /// Operataion name
        /// </summary>
        public EnumOperationName OperationName { get; set; }
        /// <summary>
        /// Operation/request status
        /// </summary>

        public EnumOperationStatus OperationStatus { get; set; }
        /// <summary>
        /// Operation/Request result
        /// </summary>
        public string OperationResult { get; set; }
        /// <summary>
        /// Request details message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Best matching result
        /// </summary>
        public ResultScore BestResult { get; set; }
        /// <summary>
        /// Details matching result
        /// </summary>
        public List<ResultScoreItem> DetailResult { get; set; }
        /// <summary>
        /// Extraction details
        /// </summary>
        [JsonIgnore]
        public ExtractionDetails ExtractionDetailes { get; set; }
        /// <summary>
        /// Template base64
        /// </summary>
        public string TemplateBase64 { get; set; }

        /// <summary>
        /// Request exception message which will be used on alert publish
        /// </summary>
        [JsonIgnore]
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// Request inner message which will be used on alert publish
        /// </summary>
        [JsonIgnore]
        public string StackTrace { get; set; }
        string IMatchingResult.ClientKey { get; set; }
    }
}
