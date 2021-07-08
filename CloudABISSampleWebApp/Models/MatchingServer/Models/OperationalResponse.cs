using CloudABISSampleWebApp.Models.MatchingServer.Enums;
using CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class OperationalResponse
    {/// <summary>
     /// 
     /// </summary>
        public IMatchingResult MatchingResult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EnumOperationalResponseStatus ResponseStatus { get; set; }
    }
}
