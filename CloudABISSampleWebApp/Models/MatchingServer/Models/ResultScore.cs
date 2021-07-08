using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    /// <summary>
    /// Result score
    /// </summary>
    public class ResultScore
    {
        /// <summary>
        /// Matching score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Match id
        /// </summary>
        public string ID { get; set; }
    }
}
