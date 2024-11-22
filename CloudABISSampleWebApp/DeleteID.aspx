<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteID.aspx.cs" Inherits="CloudABISSampleWebApp.DeleteID" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>DeleteID</title>
    <link href="Script/Style.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <script src="Script/CloudABIS-ScanR.js"></script>
    <script src="Script/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Script/bootstrap.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var engineName = getCookieValue("CABEngineName");
            if (engineName == EnumEnginesMapper.MultiModal) {
                document.getElementById("btnDeleteID").style.display = 'none';
            } else {
                var buttonID = '<%= btnDeleteID.ClientID %>';
                var button = document.getElementById(buttonID);
                if (button) {
                    button.style.display = 'block';
                }


                var buttonMultimodal = document.getElementById("btnMultimodal");
                if (buttonMultimodal) {
                    buttonMultimodal.style.display = 'none';
                }
            }
        });

        /*
         * Biometric Capture
         */
        function deleteMultimodalId() {
            debugger

            var regId = document.getElementById('txtDeleteID').value;
            if (regId == '') {
                document.getElementById('<%= lblMessage.ClientID %>').innerHTML = "Please put reg id first!"
                return;
            }

            showLoader();

            document.getElementById('<%= lblMessage.ClientID %>').innerHTML = '';



            var apiPath = CLOUDABISSCANR_BASE_API_URL;

            //Init CloudABIS Scanr
            CloudABISScanrInit(apiPath);
            var engineName = getCookieValue("CABEngineName");
            var regId = document.getElementById('txtDeleteID').value;

            if (engineName == EnumEnginesMapper.MultiModal) {

                var v12BaseAPI = getCookieValue("CABBaseURL");
                var v12ClientKey = getCookieValue("CABClientKey");
                var v12ClientAPIKey = getCookieValue("CABClientAPIKey");

                var fvBaseAPI = getCookieValue("FVBaseURL");
                var fvAppKey = getCookieValue("FVAppKey");
                var fvSecretKey = getCookieValue("FVSecretKey");
                var fvCustomerKey = getCookieValue("FVCustomerKey");

                var captureParam = {
                    RegistrationId: regId,
                    OperationName: EnumMatchingOperationName.DeleteId,
                    CloudABISV12APICredential: {
                        ClientKey: v12ClientKey,
                        ClientAPIKey: v12ClientAPIKey,
                        BaseAPIURL: v12BaseAPI
                    },
                    CloudABISFingerVeinCredentials: {
                        APIURL: fvBaseAPI,
                        AppKey: fvAppKey,
                        SecretKey: fvSecretKey,
                        CustomerKey: fvCustomerKey
                    }
                }
                MultiModalBiometricMatchingOperation(captureParam, CloudScanrAPIResponse);
            }
        }


        /*
         * Hnadle capture data
         */
        function CloudScanrAPIResponse(captureResponse) {
            debugger
            engineName = getCookieValue("CABEngineName");
            hideLoader();
            if (engineName == EnumEngines.MultiModal) {

                if (captureResponse.ResponseData != null &&
                    captureResponse.ResponseData.BiometricId != null)
                    document.getElementById('<%= lblMessage.ClientID %>').innerHTML = captureResponse.Message + captureResponse.ResponseData.BiometricId;
                else document.getElementById('<%= lblMessage.ClientID %>').innerHTML = captureResponse.Message;

            }
        }

        function showLoader() {
            document.getElementById("loader").style.display = "block";
        }
        function hideLoader() {
            document.getElementById("loader").style.display = "none";
        }
    </script>
</head>

<body style="background-color: ButtonHighlight">
    <div class="formWrapper">
        <form id="form1" runat="server" class="commonForm deleteIDForm">
            <h1 class="headline">Delete ID</h1>
            <div>
                <asp:Label ID="lblDeleteID" runat="server" Text="DeleteID" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtDeleteID" Width="272px" runat="server"></asp:TextBox>
            </div>
            <div id="loader" style="display: none;"></div>
            <div>
                <input id="btnMultimodal" type="button" value="Delete Id" onclick="deleteMultimodalId()" />
                <asp:Button ID="btnDeleteID" runat="server" Text="DeleteID" OnClick="btnDeleteID_Click" Style="display: none;" />
            </div>

            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />

            <pre><asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label></pre>
        </form>
    </div>
</body>
</html>

