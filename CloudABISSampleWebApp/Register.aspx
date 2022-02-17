<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CloudABISSampleWebApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Register</title>
    <link rel="Stylesheet" type="text/css" href="Script/Style.css" />

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <script src="Script/CloudABIS-ScanR.js"></script>
    <script src="Script/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Script/bootstrap.js" type="text/javascript"></script>

    <script type="text/javascript">

        var engineName = getCookieValue("CABEngineName");
        /*
         * Biometric Capture
         */
        function captureBiometric() {
            debugger

            showLoader();

            document.getElementById('bioImages').value = '';
            document.getElementById('bioImages').style.display = 'none';
            document.getElementById('<%= serverResult.ClientID %>').innerHTML = '';

            var deviceName = getCookieValue("CSDeviceName");
            
            document.getElementById('<%=lblCurrentDeviceName.ClientID%>').innerHTML = deviceName;

            var apiPath = CLOUDABISSCANR_BASE_API_URL;

            //Init CloudABIS Scanr
            CloudABISScanrInit(apiPath);
            var captureType = document.getElementById("captureType");
            captureType = captureType.options[captureType.selectedIndex].value;
            var quickScan = EnumFeatureMode.Disable;

            var regId = document.getElementById('txtRegID').value;



            /*API Call*/

            if (engineName == EnumEnginesMapper.FingerPrint) {
                var captureParam = {
                    DeviceName: deviceName,
                    QuickScan: quickScan,
                    CaptureType: captureType,
                    SingleCaptureMode: EnumSingleCaptureMode.LeftFingerCapture,
                    CaptureTimeOut: 180.0,
                    CaptureOperationName: EnumCaptureOperationName.ENROLL,
                }
                FingerPrintCapture(captureParam, CaptureResult);
            }
            else if (engineName == EnumEnginesMapper.Iris) {
                var captureParam = {
                    DeviceName: deviceName,
                    QuickScan: quickScan,
                    FaceImage: EnumFeatureMode.Disable,
                    CaptureTimeOut: 180.0,
                    CaptureOperationName: EnumCaptureOperationName.ENROLL,
                }

                IrisCapture(captureParam, CaptureResult);
            }
            else if (engineName == EnumEnginesMapper.Face) {
                var captureParam = {
                    DeviceName: deviceName,
                    QuickScan: quickScan,
                    HasFaceSkip: EnumFeatureMode.Disable,
                    FaceImageFormat: EnumFaceImageFormat.Jpeg,
                    CaptureTimeOut: 180.0,
                    CaptureOperationName: EnumCaptureOperationName.ENROLL,
                }
                FaceCapture(captureParam, CaptureResult);
            }
            else if (engineName == EnumEnginesMapper.MultiModal) {

                var v12BaseAPI = getCookieValue("CABBaseURL");
                var v12ClientKey = getCookieValue("CABClientKey");
                var v12ClientAPIKey = getCookieValue("CABClientAPIKey");

                var fvBaseAPI = getCookieValue("FVBaseURL");
                var fvAppKey = getCookieValue("FVAppKey");
                var fvSecretKey = getCookieValue("FVSecretKey");
                var fvCustomerKey = getCookieValue("FVCustomerKey");

                var captureParam = {
                    RegistrationId: regId,
                    OperationName: EnumMatchingOperationName.Register,
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
                MultiModalBiometricMatchingOperation(captureParam, CaptureResult);
            }
        }

        /*
         * Hnadle capture data
         */
        function CaptureResult(captureResponse) {
           
            engineName = getCookieValue("CABEngineName");
            hideLoader();
            if (engineName == EnumEngines.MultiModal) {

                if (captureResponse.ResponseData != null &&
                    captureResponse.ResponseData.BiometricId != null)
                    document.getElementById('<%= serverResult.ClientID %>').innerHTML = captureResponse.Message + captureResponse.ResponseData.BiometricId;
                else document.getElementById('<%= serverResult.ClientID %>').innerHTML = captureResponse.Message;

            } else {
                if (captureResponse.CloudScanrStatus != null && captureResponse.CloudScanrStatus.Success) {


                    if (captureResponse.Images != null) {
                        document.getElementById('bioImages').value = JSON.stringify(captureResponse.Images);
                    }
                    else {
                        document.getElementById('bioImages').style.display = 'none';
                    }
                    document.getElementById('<%= btnSubmit.ClientID %>').style.display = "block";
                    document.getElementById('<%= serverResult.ClientID %>').innerHTML = "Capture success. Please click on register button";
                }
                else if (captureResponse.CloudScanrStatus != null) {
                    document.getElementById('<%= serverResult.ClientID %>').innerHTML = captureResponse.CloudScanrStatus.Message;
                } else {
                    document.getElementById('<%= serverResult.ClientID %>').innerHTML = captureResponse;
                }
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
        <form id="form1" runat="server" class="commonForm registerForm">
            <h1 class="headline">Registration</h1>
            <div class="mt-10">
                <label>Capture Type:</label>
                <select name="captureType" id="captureType">
                    <option value="SingleCapture">Single Capture</option>
                    <option value="DoubleCapture">Double Capture</option>
                </select>
            </div>
            <div>
                <label for="registrationID">Registration Id</label>
                <asp:TextBox ID="txtRegID" runat="server"></asp:TextBox>
            </div>
            <div id="loader" style="display: none;"></div>
            <div>
                <label class="currentDeviceCaption">Current Device Name:</label><asp:Label ID="lblCurrentDeviceName" runat="server" Text="..."></asp:Label>
                <input type="button" value="BioMetric Capture" onclick="captureBiometric()" />
                <asp:Button ID="btnSubmit" runat="server" Text="Register" Enabled="true" Style="display: none" OnClick="btnRegister_Click" />
                <asp:Button ID="Button1" runat="server" Text="Back" OnClick="BtnBack_Click" />
                &nbsp;<pre><asp:Label ID="serverResult" runat="server" Text=""></asp:Label></pre>

                <asp:TextBox Width="350px" ID="fileStaveStatus" runat="server" Visible="false" TextMode="MultiLine" Text="Captured Template save at"></asp:TextBox>
            </div>
            <pre><asp:TextBox ID="bioImages" runat="server" CssClass="pagetitleValue" Style="display: none;" TextMode="MultiLine" Text="" Height="263px" Width="663px"></asp:TextBox></pre>
        </form>
    </div>
</body>
</html>
