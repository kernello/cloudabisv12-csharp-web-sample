using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Utilities
{
    public class AbisConstants
    {
        //Biometric API
        public const string BIOMETRIC_ISREGISTERED_API_PATH = "api/Biometrics/IsRegistered";
        public const string BIOMETRIC_REGISTER_API_PATH = "api/Biometrics/Register";
        public const string BIOMETRIC_IDENTIFY_API_PATH = "api/Biometrics/Identify";
        public const string BIOMETRIC_VERIFY_API_PATH = "api/Biometrics/Verify";
        public const string BIOMETRIC_UPDATE_API_PATH = "api/Biometrics/Update";
        public const string BIOMETRIC_CHANGE_ID_API_PATH = "api/Biometrics/ChangeID";
        public const string BIOMETRIC_DELETE_ID_API_PATH = "api/Biometrics/DeleteID";

        //Usages
        public const string USAGES_API_PATH = "api/Usages/";

        //Token
        public const string AUTHORIZATION_TOKEN_API_PATH = "api/Authorizations/Token";

        public const string ABISUnAuthorize = "BioPlugin Server UnAuthorized.";
        public const string ABISUnreachable = "BioPlugin Server Unreachable.";
        public const string ABISBadGateWay = "BioPlugin Server Bad Gateway";

        public const string SUCCESS = "Success";
        public const string FAILED = "Failed";
    }
}