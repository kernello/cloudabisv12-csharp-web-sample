using CloudABISSampleWebApp.CloudABIS;
using CloudABISSampleWebApp.Models;
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
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               if (string.IsNullOrEmpty(SessionManager.CloudABISAPIToken) || SessionManager.CloudABISCredentials == null) Response.Redirect("AppConfiguration.aspx");
               
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                serverResult.Text = "Start updating...";
                string images = this.bioImages.Text.ToString();
                string updateID = txtUpdateID.Text.ToString();

                if (!string.IsNullOrEmpty(images) && !string.IsNullOrEmpty(updateID))
                {
                    string token = SessionManager.CloudABISAPIToken;
                    if (!string.IsNullOrEmpty(token))
                    {
                        CloudABISConnector cloudABISConnector = new CloudABISConnector(SessionManager.CloudABISCredentials.BaseAPIURL);

                        var request = new BiometricGenericRequest
                        {
                            ClientKey = SessionManager.CloudABISCredentials.ClientKey,
                            RegistrationID = updateID,
                            Images = JsonConvert.DeserializeObject<BiometricImages>(images)
                        };
                        MatchingResult response = Task.Run(() => cloudABISConnector.UpdateAsync(request, token)).Result;

                        serverResult.Text = CloudABISResultParser.GetBiometricMatchingResponse(response, EnumOperationName.Update).Message; //JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                    else
                    {
                        Response.Redirect("AppConfiguration.aspx");
                    }
                }
                else if (string.IsNullOrEmpty(updateID))
                {
                    serverResult.Text = "Please put update id first";
                }
                else
                    serverResult.Text = "Please biometric capture first";
            }
            catch (Exception ex)
            {
                serverResult.Visible = true;
                serverResult.Text = ex.Message;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CloudABISHome.aspx");
        }
    }
}