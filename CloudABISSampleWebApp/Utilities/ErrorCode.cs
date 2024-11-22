using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Utilities
{
    public class ErrorCode
    {
        #region CloudABIS v12 (0200-0299)
        /// <summary>
        /// CS0200: Token information doesn't exist in the local session
        /// </summary>
        public const string CS0200 = "CS0200";
        public const string CS0200_MESSAGE = "Token information doesn't exist in the local session";

        /// <summary>
        /// CS0201: Biometric Id is required
        /// </summary>
        public const string CS0201 = "CS0201";
        public const string CS0201_MESSAGE = "Biometric Id is required";


        //IsRegister
        /// <summary>
        /// CS0202: There is biometric data enrolled with the requested ID
        /// </summary>
        public const string CS0202 = "CS0202";
        public const string CS0202_MESSAGE = "There is biometric data enrolled with the requested ID.";
        /// <summary>
        /// CS0203: There is not any biometric data enrolled with the requested ID.
        /// </summary>
        public const string CS0203 = "CS0203";
        public const string CS0203_MESSAGE = "There is not any biometric data enrolled with the requested ID.";

        //Register
        /// <summary>
        /// CS0204: The submitted biometric data matched that of an enrolled member.
        /// </summary>
        public const string CS0204 = "CS0204";
        public const string CS0204_MESSAGE = "The submitted biometric data matched that of an enrolled member.";
        /// <summary>
        /// CS0205: The Member ID and associated biometric data added to system.
        /// </summary>
        public const string CS0205 = "CS0205";
        public const string CS0205_MESSAGE = "The Member ID and associated biometric data added to system.";
        /// <summary>
        /// CS0206: Enrollment failed.
        /// </summary>
        public const string CS0206 = "CS0206";
        public const string CS0206_MESSAGE = "Enrollment failed.";
        /// <summary>
        /// CS0207: There is biometric data enrolled with the requested Member ID.
        /// </summary>
        public const string CS0207 = "CS0207";
        public const string CS0207_MESSAGE = "There is biometric data enrolled with the requested Member ID.";
        /// <summary>
        /// CS0208: RegistrationID exists in database but doesn't exist in cache.
        /// </summary>
        public const string CS0208 = "CS0208";
        public const string CS0208_MESSAGE = "RegistrationID exists in database but doesn't exist in cache.";

        //Identify
        /// <summary>
        /// CS0209: The submitted biometric data matched that of an enrolled member.
        /// </summary>
        public const string CS0209 = "CS0209";
        public static string CS0209_MESSAGE = "The submitted biometric data matched that of an enrolled member. MemberId: {0}";
        /// <summary>
        /// CS0210: No enrolled members matched against the submitted biometric data.
        /// </summary>
        public const string CS0210 = "CS0210";
        public const string CS0210_MESSAGE = "No enrolled members matched against the submitted biometric data.";

        //Verify
        /// <summary>
        /// CS0211: Verification successful. The submitted biometric data matched the requested member's enrolled biometric data.
        /// </summary>
        public const string CS0211 = "CS0211";
        public const string CS0211_MESSAGE = "Verification successful. The submitted biometric data matched the requested member's enrolled biometric data.";
        /// <summary>
        /// CS0212: Verification failed. The submitted biometric data did not match the requested member's enrolled biometric data.
        /// </summary>
        public const string CS0212 = "CS0212";
        public const string CS0212_MESSAGE = "Verification failed. The submitted biometric data did not match the requested member's enrolled biometric data.";
        /// <summary>
        /// CS0213: The Member ID doesn't exist in the system.
        /// </summary>
        public const string CS0213 = "CS0213";
        public const string CS0213_MESSAGE = "The Member ID doesn't exist in the system.";

        //Update
        /// <summary>
        /// CS0214: Update successful. The biometric data associated with the requested Member ID was updated in the system.
        /// </summary>
        public const string CS0214 = "CS0214";
        public const string CS0214_MESSAGE = "Update successful. The biometric data associated with the requested Member ID was updated in the system.";
        /// <summary>
        /// CS0215: Update Failed.
        /// </summary>
        public const string CS0215 = "CS0215";
        public const string CS0215_MESSAGE = "Update Failed.";
        /// <summary>
        /// CS0216: The Member ID doesn't exist in the system.
        /// </summary>
        public const string CS0216 = "CS0216";
        public const string CS0216_MESSAGE = "The Member ID doesn't exist in the system.";

        //ChangeId
        /// <summary>
        /// CS0217: Change of ID successful. The Member ID was changed to the specified new ID.
        /// </summary>
        public const string CS0217 = "CS0217";
        public const string CS0217_MESSAGE = "Change of ID successful. The Member ID was changed to the specified new ID.";
        /// <summary>
        /// CS0218: Change of ID failed.
        /// </summary>
        public const string CS0218 = "CS0218";
        public const string CS0218_MESSAGE = "Change of ID failed.";
        /// <summary>
        /// CS0219: The Member ID intent for change doesn't exist in the system.
        /// </summary>
        public const string CS0219 = "CS0219";
        public const string CS0219_MESSAGE = "The Member ID intent for change doesn't exist in the system.";


        //DeleteId
        /// <summary>
        /// CS0220: Deletion successful. The Member ID and associated biometric data removed from system.
        /// </summary>
        public const string CS0220 = "CS0220";
        public const string CS0220_MESSAGE = "Deletion successful. The Member ID and associated biometric data removed from system.";
        /// <summary>
        /// CS0221: Deletion failed.
        /// </summary>
        public const string CS0221 = "CS0221";
        public const string CS0221_MESSAGE = "Deletion failed.";
        /// <summary>
        /// CS0222: The Member ID doesn't exist in the system.
        /// </summary>
        public const string CS0222 = "CS0222";
        public const string CS0222_MESSAGE = "The Member ID doesn't exist in the system.";

        //Extraction
        /// <summary>
        /// CS0223: Biometric images extraction success.
        /// </summary>
        public const string CS0223 = "CS0223";
        public const string CS0223_MESSAGE = "Biometric images extraction success.";
        /// <summary>
        /// CS0224: Biometric images extraction failed, please provide good quality images and try again.
        /// </summary>
        public const string CS0224 = "CS0224";
        public const string CS0224_MESSAGE = "Biometric images extraction failed, please provide good quality images and try again.";


        //Others
        /// <summary>
        /// CS0225: The submitted biometric data was not valid.
        /// </summary>
        public const string CS0225 = "CS0225";
        public const string CS0225_MESSAGE = "The submitted biometric data was not valid.";
        /// <summary>
        /// CS0226: The specified clientKey was not found in the system. Please contat your vendor for assistance.
        /// </summary>
        public const string CS0226 = "CS0226";
        public const string CS0226_MESSAGE = "The specified clientKey was not found in the system. Please contat your vendor for assistance.";
        /// <summary>
        /// CS0227: An unexpected system error was encountered. Please contact your vendor for assistance.
        /// </summary>
        public const string CS0227 = "CS0227";
        public const string CS0227_MESSAGE = "An unexpected system error was encountered. Please contact your vendor for assistance.";
        /// <summary>
        /// CS0228: The submitted request was not correctly formatted.
        /// </summary>
        public const string CS0228 = "CS0228";
        public const string CS0228_MESSAGE = "The submitted request was not correctly formatted.";
        /// <summary>
        /// CS0229: A system license limitation prevented your request from being fulfilled. Please contact your vendor for assistance.
        /// </summary>
        public const string CS0229 = "CS0229";
        public const string CS0229_MESSAGE = "A system license limitation prevented your request from being fulfilled. Please contact your vendor for assistance.";
        /// <summary>
        /// CS0230: The submitted BiometricXml was not correctly formatted.
        /// </summary>
        public const string CS0230 = "CS0230";
        public const string CS0230_MESSAGE = "The submitted BiometricXml was not correctly formatted.";
        #endregion
        #region Common 401, 500, 502, 503
        public const string CSC401 = "401";
        public const string CSC401_MESSAGE = "Unauthorized";
        public const string CSC500 = "500";
        public const string CSC500_MESSAGE = "Internal error";
        public const string CSC502 = "502";
        public const string CSC502_MESSAGE = "Bad gateway";
        public const string CSC503 = "503";
        public const string CSC503_MESSAGE = "Service unavailable";


        #endregion
    }
}