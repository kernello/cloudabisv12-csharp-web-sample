using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    /// <summary>
    /// Score index
    /// </summary>
    public class ScoreIndex
    {
        /// <summary>
        /// Matching score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Match finger/pos index
        /// </summary>
        public int? MatchedIndex { get; set; }
    }
}
