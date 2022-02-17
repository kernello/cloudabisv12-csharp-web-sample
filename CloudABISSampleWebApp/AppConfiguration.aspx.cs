using CloudABISSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudABISSampleWebApp
{
    public partial class AppConfiguration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadConfiguration();
                //Clear session
                SessionManager.CloudABISCredentials = null;
                SessionManager.CloudABISAPIToken = string.Empty;

            }
        }
        private void LoadConfiguration()
        {
            try
            {

                txtAPIBaseURL.Text = BaseURL();
                txtClientApiKey.Text = ClientAPIKey();
                txtClientKey.Text = ClientKey();

                //fv
                txtFVAPIUrl.Text = FVBaseURL();
                txtFVAppKey.Text = FVAppKey();
                txtFVSecretKey.Text = FVSecretKey();
                txtFVCustomerKey.Text = FVCustomerKey();

            }
            catch (Exception)
            {
            }
        }
        #region Configuration
        #region FV
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string FVBaseURL()
        {
            try
            {
                if (Request.Cookies != null
                && Request.Cookies.AllKeys.Contains("FVBaseURL"))
                    return Request.Cookies["FVBaseURL"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string FVAppKey()
        {
            try
            {
                if (Request.Cookies != null
                && Request.Cookies.AllKeys.Contains("FVAppKey"))
                    return Request.Cookies["FVAppKey"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string FVSecretKey()
        {
            try
            {
                if (Request.Cookies != null
              && Request.Cookies.AllKeys.Contains("FVSecretKey"))
                    return Request.Cookies["FVSecretKey"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string FVCustomerKey()
        {
            try
            {
                if (Request.Cookies != null && Request.Cookies.AllKeys.Contains("FVCustomerKey"))
                    return Request.Cookies["FVCustomerKey"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string BaseURL()
        {
            try
            {
                if (Request.Cookies != null
                   && Request.Cookies.AllKeys.Contains("CABBaseURL"))
                    return Request.Cookies["CABBaseURL"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string ClientKey()
        {
            try
            {
                if (Request.Cookies != null
                    && Request.Cookies.AllKeys.Contains("CABClientKey"))
                    return Request.Cookies["CABClientKey"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string ClientAPIKey()
        {
            try
            {
                if (Request.Cookies != null
                    && Request.Cookies.AllKeys.Contains("CABClientAPIKey"))
                    return Request.Cookies["CABClientAPIKey"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string EngineName()
        {
            try
            {
                if (Request.Cookies != null
                   && Request.Cookies.AllKeys.Contains("CABEngineName"))
                    return Request.Cookies["CABEngineName"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string DeviceName()
        {
            try
            {
                if (Request.Cookies != null
                    && Request.Cookies.AllKeys.Contains("CSDeviceName"))
                    return Request.Cookies["CSDeviceName"].Value.ToString();
                else return "";
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CloudABISHome.aspx");
        }

    }
}