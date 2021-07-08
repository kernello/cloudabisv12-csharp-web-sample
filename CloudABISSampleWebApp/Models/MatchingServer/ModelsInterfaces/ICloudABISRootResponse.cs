using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces
{
    public interface ICloudABISRootResponse<T> : ICloudABISResponse
    {
        /// <summary>
        /// Response data where containts all data
        /// </summary>
        T ResponseData { get; set; }
    }
}
