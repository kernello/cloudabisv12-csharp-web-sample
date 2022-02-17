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
        public const string SUCCESS_CAPITAL = "SUCCESS";

        #region CloudABIS Message Details
        // IMatchingResult Response messages 
        public const string UCSResponseMessageIsRegisterSuccess = "There is biometric data enrolled with the requested ID.";
        public const string UCSResponseMessageIsRegisterFailed = "There is not any biometric data enrolled with the requested ID.";

        public const string UCSResponseMessageRegisterMatchFound = "The submitted biometric data matched that of an enrolled member.";
        public const string UCSResponseMessageRegisterSuccess = "The Member ID and associated biometric data added to system.";
        public const string UCSResponseMessageRegisterFailed = "Enrollment failed.";
        public const string UCSResponseMessageRegisterIdExist = "There is biometric data enrolled with the requested Member ID.";
        public const string UCSResponseMessageRegisterIdNotExistInCache = "RegistrationID exists in database but doesn't exist in cache.";

        public const string UCSResponseMessageIdentifyMatchFound = "The submitted biometric data matched that of an enrolled member.";
        public const string UCSResponseMessageIdentifyNoMatchFound = "No enrolled members matched against the submitted biometric data.";

        public const string UCSResponseMessageVerifySuccess = "Verification successful. The submitted biometric data matched the requested member's enrolled biometric data.";
        public const string UCSResponseMessageVerifyFailed = "Verification failed. The submitted biometric data did not match the requested member's enrolled biometric data.";
        public const string UCSResponseMessageVerifyIdNotExist = "The Member ID doesn't exist in the system.";

        public const string UCSResponseMessageUpdateSuccess = " Update successful. The biometric data associated with the requested Member ID was updated in the system.";
        public const string UCSResponseMessageUpdateFailed = "Update Failed.";
        public const string UCSResponseMessageUpdateIdNotExist = "The Member ID doesn't exist in the system.";

        public const string UCSResponseMessageChangeIDSuccess = "Change of ID successful. The Member ID was changed to the specified new ID.";
        public const string UCSResponseMessageChangeIDFailed = "Change of ID failed.";
        public const string UCSResponseMessageChangeIDIdNotExist = "The Member ID intent for change doesn't exist in the system.";

        public const string UCSResponseMessageDeleteSuccess = "Deletion successful. The Member ID and associated biometric data removed from system.";
        public const string UCSResponseMessageDeleteFailed = "Deletion failed.";
        public const string UCSResponseMessageDeleteIdNotExist = "The Member ID doesn't exist in the system.";

        public const string UCSResponseMessageExtractionSuccess = "Biometric images extraction success.";
        public const string UCSResponseMessageExtractionFailed = "Biometric images extraction failed, please provide good quality images and try again...";

        public const string UCSResponseMessageBadTemplate = "The submitted biometric data was not valid.";
        public const string UCSResponseMessageClientNotFound = "The specified clientKey was not found in the system. Please contat your vendor for assistance.";
        public const string UCSResponseMessageServerException = "An unexpected system error was encountered. Please contact your vendor for assistance.";


        public const string UCSResponseMessageInvalidRequest = "The submitted request was not correctly formatted.";
        public const string UCSResponseMessageLicenseError = "A system license limitation prevented your request from being fulfilled. Please contact your vendor for assistance.";
        public const string UCSResponseMessageInternalError = "An unexpected system error was encountered. Please contact your vendor for assistance.";
        public const string UCSResponseMessageInvalidTemplate = "The submitted BiometricXml was not correctly formatted.";


        //Register result
        /// <summary>
        /// Register/Update success
        /// </summary>
        public const string RegisterOrUpdateSuccess = "SUCCESS";
        //Register result
        /// <summary>
        /// Register/Update failed
        /// </summary>
        public const string RegisterOrUpdateFailed = "FAILED";

        // IsRegister result
        /// <summary>
        /// Id exist in the system
        /// </summary>
        public const string IsRegisterSuccess = "YES";
        /// <summary>
        /// Id not exist in the system
        /// </summary>
        public const string IsRegisterFailed = "NO";

        //Delete result
        /// <summary>
        /// Delete success
        /// </summary>
        public const string DeleteSuccess = "DS";
        /// <summary>
        /// Delete failed
        /// </summary>
        public const string DeleteFailed = "DF";

        //Verify result
        /// <summary>
        /// Verify success
        /// </summary>
        public const string VerifySuccess = "VS";
        /// <summary>
        /// Verify failed
        /// </summary>
        public const string VerifyFailed = "VF";

        //ChangeID result
        /// <summary>
        /// Change id success
        /// </summary>
        public const string ChangeIDSuccess = "CS";
        /// <summary>
        /// Change id failed
        /// </summary>
        public const string ChangeIDFailed = "CF";
        /// <summary>
        /// License error
        /// </summary>
        public const string LicenseError = "LICENSE_ERROR";
        /// <summary>
        /// Internal error
        /// </summary>
        public const string InternalError = "INTERNAL_ERROR";
        /// <summary>
        /// Internal error
        /// </summary>
        public const string InvalidRequest = "INVALID_REQUEST";
        /// <summary>
        /// Server exception
        /// </summary>
        public const string ServerException = "SERVER_EXCEPTION";
        /// <summary>
        /// Request format error
        /// </summary>
        public const string RequestFormatError = "REQUEST_FORMAT_ERROR";
        /// <summary>
        /// Poor image quality
        /// </summary>
        public const string PoorImageQuality = "POOR_IMAGE_QUALITY";
        /// <summary>
        /// Id exist
        /// </summary>
        public const string IdExist = "ID_EXIST";
        /// <summary>
        /// Id not exist
        /// </summary>
        public const string IdNotExist = "ID_NOT_EXIST";

        /// <summary>
        /// Client not found
        /// </summary>
        public const string ClientNotFound = "CLIENT_NOT_FOUND";
        /// <summary>
        /// Client not set yet in the system
        /// </summary>
        public const string ClientNotSetYet = "CLIENT_NOT_SET_YET";
        /// <summary>
        /// Client exist
        /// </summary>
        public const string ClientExist = "CLIENT_EXIST";
        /// <summary>
        /// Invalid parameter
        /// </summary>
        public const string InvalidParameter = "INVALID_PARAMETER";


        /// <summary>
        /// Match found
        /// </summary>
        public const string MatchFound = "MATCH_FOUND";
        /// <summary>
        /// Match not found
        /// </summary>
        public const string NoMatchFound = "NO_MATCH_FOUND";

        /// <summary>
        /// Bad request
        /// </summary>
        public const string BadRequest = "BAD_REQUEST";
        /// <summary>
        /// Bad template
        /// </summary>
        public const string BadTemplate = "BAD_TEMPLATE";
        /// <summary>
        /// Api error
        /// </summary>
        public const string ApiError = "API_ERROR";

        /// <summary>
        /// 
        /// </summary>
        public const string ExtractionFailed = "EXTRACTION_FAILED";
        #endregion
    }
}