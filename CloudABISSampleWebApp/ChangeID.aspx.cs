using CloudABISSampleWebApp.CloudABIS;
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
    public partial class ChangeID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if ((string.IsNullOrEmpty(SessionManager.CloudABISAPIToken) || SessionManager.CloudABISCredentials == null)) Response.Redirect("AppConfiguration.aspx");

            }
        }

        protected void btnChangeID_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "Start Change ID operation...";
                if (!string.IsNullOrEmpty(txtOldID.Text.Trim().ToString()) && !string.IsNullOrEmpty(txtNewID.Text.Trim().ToString()))
                {
                    string newID = txtNewID.Text.Trim().ToString();
                    string oldID = txtOldID.Text.Trim().ToString();

                    string token = SessionManager.CloudABISAPIToken;
                    if (!string.IsNullOrEmpty(token))
                    {
                        CloudABISConnector cloudABISConnector = new CloudABISConnector(SessionManager.CloudABISCredentials.BaseAPIURL);

                        var request = new ChangeIdRequest
                        {
                            ClientKey = SessionManager.CloudABISCredentials.ClientKey,
                            NewRegistrationId = newID,
                            RegistrationId = oldID
                        };
                        MatchingResult response = Task.Run(() => cloudABISConnector.ChangeIdAsync(request, token)).Result;

                        lblMessage.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                    else
                    {
                        Response.Redirect("AppConfiguration.aspx");
                    }
                }
                else if (string.IsNullOrEmpty(txtNewID.Text.Trim())) lblMessage.Text = "Please give New ID";
                else if (string.IsNullOrEmpty(txtOldID.Text.Trim())) lblMessage.Text = "Please give Old ID";
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