<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IsRegistered.aspx.cs" Inherits="CloudABISSampleWebApp.IsRegistered" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>IsRegistered</title>
    <link href="Script/Style.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <script src="Script/CloudABIS-ScanR.js"></script>
    <script src="Script/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Script/bootstrap.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var engineName = getCookieValue("CABEngineName");
            if (engineName == EnumEnginesMapper.MultiModal) {
                document.getElementById("divMultiModal").style.display = 'block';
                document.getElementById("divNoMultiModal").style.display = 'none';

            } else {
                document.getElementById("divMultiModal").style.display = 'none';
                document.getElementById("divNoMultiModal").style.display = 'block';

               <%-- var buttonID = '<%= btnIsRegistered.ClientID %>';
                var button = document.getElementById(buttonID);
                if (button) {
                    button.style.display = 'block';
                }

                var buttonIsRegisteredMultimodal = document.getElementById("btnIsRegisteredMultimodal");
                if (buttonIsRegisteredMultimodal) {
                    buttonIsRegisteredMultimodal.style.display = 'none';
                }--%>

            }
        });

        /*
         * isRegistered Multimodal
         */
        function isRegisteredMultimodal() {
           

            var regId = document.getElementById('txtRegisterID').value;
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
                    OperationName: EnumMatchingOperationName.IsRegistered,
                    CloudABISAPICredential: {
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
        <form id="form1" runat="server" class="commonForm">

            <h1 class="headline">Checking an ID already exist or not</h1>
            <label for="ID">Registration Id:</label>
            <asp:TextBox ID="txtRegisterID" Width="272px" runat="server"></asp:TextBox>
            <div id="divMultiModal">
                <input id="btnIsRegisteredMultimodal" type="button" value="IsRegistered" onclick="isRegisteredMultimodal()" />

            </div>
            <div id="divNoMultiModal" style="display: none;">
                <asp:Button ID="btnIsRegistered" runat="server" Text="IsRegistered" OnClick="btnIsRegistered_Click" />
            </div>

            <div id="loader" style="display: none;"></div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
            <div>
                <pre><asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label></pre>
            </div>

        </form>
    </div>
</body>
</html>
