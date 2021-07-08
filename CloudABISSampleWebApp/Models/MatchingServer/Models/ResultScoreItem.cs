using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models
{
    /// <summary>
    /// Result score item
    /// </summary>
    public class ResultScoreItem : ResultScore
    {
        /// <summary>
        /// Finger print score
        /// </summary>
        public int? FingersScore { get; set; }
        /// <summary>
        /// Matchd fingers
        /// </summary>
        public List<ScoreIndex> MatchedFingers { get; set; }

        /// <summary>
        /// Iris scire
        /// </summary>
        public int? IrisesScore { get; set; }
        /// <summary>
        /// Matched Irises
        /// </summary>
        public List<ScoreIndex> MatchedIrises { get; set; }

        /// <summary>
        /// Face score
        /// </summary>
        public int? FacesScore { get; set; }
        /// <summary>
        /// Face  match indes
        /// </summary>
        public int? FacesMatchedIndex { get; set; }
        /// <summary>
        /// Matched faces
        /// </summary>
        public List<ScoreIndex> MatchedFaces { get; set; }

    }
}
