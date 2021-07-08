using CloudABISSampleWebApp.CloudABIS;
using CloudABISSampleWebApp.Models.MatchingServer.Models;
using CloudABISSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudABISSampleWebApp
{
    public partial class CloudABISHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set key value in the session
                LoadCloudABISToken();


            }
        }

        private void LoadCloudABISToken()
        {
            CloudABISAPICredential cloudABISCredentials = new CloudABISAPICredential();
            cloudABISCredentials.BaseAPIURL = BaseURL(); //AppSettingsReader.CloudABISClientAPIKey;
            cloudABISCredentials.ClientKey = ClientKey();//AppSettingsReader.CloudABISClientKey;
            cloudABISCredentials.ClientAPIKey = ClientAPIKey(); //AppSettingsReader.CloudABISv12_API_URL;

            if (!string.IsNullOrEmpty(cloudABISCredentials.BaseAPIURL)
                && !string.IsNullOrEmpty(cloudABISCredentials.ClientKey)
                && !string.IsNullOrEmpty(cloudABISCredentials.ClientAPIKey))
            {
                //Read token from CloudABIS Server
                CloudABISConnector cloudABISConnector = new CloudABISConnector(cloudABISCredentials.BaseAPIURL);


                CloudABISRootResponse<BioPluginToken> response = Task.Run(() => cloudABISConnector.GenerateTokenAsync(cloudABISCredentials)).Result;

                if (response.Status.Equals(AbisConstants.SUCCESS) && !string.IsNullOrEmpty(response.ResponseData.AccessToken))
                {
                    SessionManager.CloudABISAPIToken = response.ResponseData.AccessToken;
                    SessionManager.CloudABISCredentials = cloudABISCredentials;
                    //
                    lblStatus.Text = "Device: " + DeviceName() + ", Engine: " + EngineName();
                }
                else lblStatus.Text = "CloudABIS Not Authorized!. Please check credentails";
            }
            else Response.Redirect("AppConfiguration.aspx");
            //lblStatus.Text = "CloudABIS required credentials not found!. Please check application Configuration.";

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

        protected void lnkIsRegistered_Click(object sender, EventArgs e)
        {
            Response.Redirect("IsRegistered.aspx");
        }

        protected void lnkChangeID_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeID.aspx");
        }

        protected void lnkDeleteID_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteID.aspx");
        }

        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void lnkIdentify_Click(object sender, EventArgs e)
        {
            Response.Redirect("Identify.aspx");
        }

        protected void lnkVerify_Click(object sender, EventArgs e)
        {
            Response.Redirect("Verify.aspx");
        }
        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }
        protected void lnkChangeActiveDevice_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppConfiguration.aspx");
        }
    }
}