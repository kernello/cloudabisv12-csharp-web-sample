using CloudABISSampleWebApp.Models.MatchingServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBiometricRequest
    {
        /// <summary>
        /// 
        /// </summary>
        string ClientKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string SequenceNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string RegistrationID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string NewRegistrationID { get; set; }
        bool CheckAllTogether { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string TemplateBase64 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        BiometricImages Images { get; set; }
        ExtractionDetails ExtractionDetails { get; set; }
        EnumOperationName OperationName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        byte[] GetNTemplate();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateBytes"></param>
        void SetNTemplate(byte[] templateBytes);
    }
}
