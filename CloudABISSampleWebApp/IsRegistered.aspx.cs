using CloudABISSampleWebApp.CloudABIS;
using CloudABISSampleWebApp.Models.MatchingServer.Enums;
using CloudABISSampleWebApp.Models.MatchingServer.Models;
using CloudABISSampleWebApp.Models.MatchingServer.Models.Request;
using CloudABISSampleWebApp.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudABISSampleWebApp
{
    public partial class IsRegistered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if ((string.IsNullOrEmpty(SessionManager.CloudABISAPIToken) || SessionManager.CloudABISCredentials == null)) Response.Redirect("AppConfiguration.aspx");

            }
        }

        protected void btnIsRegistered_Click(object sender, EventArgs e)
        {

            try
            {
                lblMessage.Text = "Start IsRegister operation...";
                if (!string.IsNullOrEmpty(txtRegisterID.Text.Trim().ToString()))
                {

                    string regID = txtRegisterID.Text.Trim().ToString();
                    string token = SessionManager.CloudABISAPIToken;
                    if (!string.IsNullOrEmpty(token))
                    {
                        CloudABISConnector cloudABISConnector = new CloudABISConnector(SessionManager.CloudABISCredentials.BaseAPIURL);

                        var request = new IsRegisterRequest
                        {
                            ClientKey = SessionManager.CloudABISCredentials.ClientKey,
                            RegistrationID = regID
                        };
                        MatchingResult response = Task.Run(() => cloudABISConnector.IsRegisteredAsync(request, token)).Result;

                        lblMessage.Text = CloudABISResultParser.GetBiometricMatchingResponse(response, EnumOperationName.IsRegistered).Message;//JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                    else
                    {
                        Response.Redirect("AppConfiguration.aspx");
                    }
                }
                else lblMessage.Text = "Please give an ID";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CloudABISHome.aspx");
        }
    }
}