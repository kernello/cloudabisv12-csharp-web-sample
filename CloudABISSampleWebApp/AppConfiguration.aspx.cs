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
            }
            catch (Exception)
            {
            }
        }
        #region Configuration
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string BaseURL()
        {
            try
            {
                return Request.Cookies["CABBaseURL"].Value.ToString();
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
                return Request.Cookies["CABClientKey"].Value.ToString();
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
                return Request.Cookies["CABClientAPIKey"].Value.ToString();
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
                return Request.Cookies["CABEngineName"].Value.ToString();
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
                return Request.Cookies["CSDeviceName"].Value.ToString();
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