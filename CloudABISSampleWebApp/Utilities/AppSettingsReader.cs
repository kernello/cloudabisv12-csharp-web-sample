using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Utilities
{
    public class AppSettingsReader
    {



        #region
        /// <summary>
        /// 
        /// </summary>
        public static string CloudABISv12_API_URL
        {
            get { return ReadMyConfig("CloudABISv12APIURL"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string CloudABISClientKey
        {
            get { return ReadMyConfig("CloudABISClientKey"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string CloudABISClientAPIKey
        {
            get { return ReadMyConfig("CloudABISClientAPIKey"); }
        }
        #endregion
        /// <summary>
        /// Read application cofig value using the key
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        internal static string ReadMyConfig(string strKey)
        {
            try
            {
                return !string.IsNullOrEmpty(ConfigurationSettings.AppSettings[strKey]) ? ConfigurationSettings.AppSettings[strKey] : string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}