using CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudABISSampleWebApp.Models.MatchingServer.Enums;

namespace CloudABISSampleWebApp.Models.MatchingServer.Models.Request
{
    public class BiometricRequest: IBiometricRequest
    {
        /// <summary>
        /// 
        /// </summary>
       public string ClientKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SequenceNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegistrationID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NewRegistrationID { get; set; }
        public bool CheckAllTogether { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TemplateBase64 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BiometricImages Images { get; set; }
        

        public ExtractionDetails ExtractionDetails { get; set; }
        public EnumOperationName OperationName { get; set; }

        #region Server used methods
        public byte[] GetNTemplate() { return Convert.FromBase64String(this.TemplateBase64); }
        public void SetNTemplate(byte[] templateBytes) { this.TemplateBase64 = Convert.ToBase64String(templateBytes); }

        #endregion Server used methods
    }
}
