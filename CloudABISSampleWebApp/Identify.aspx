<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Identify.aspx.cs" Inherits="CloudABISSampleWebApp.Identify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Identify</title>
    <link rel="Stylesheet" type="text/css" href="Script/Style.css" />

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <script src="Script/CloudABIS-ScanR.js"></script>
    <script src="Script/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Script/bootstrap.js" type="text/javascript"></script>

    <script type="text/javascript">

        var engineName = EnumEngines.FingerPrint;
        /*
         * Biometric Capture
         */
        function captureBiometric() {
            showLoader();

            document.getElementById('bioImages').value = '';
            document.getElementById('bioImages').style.display = 'none';
            document.getElementById('<%= serverResult.ClientID %>').innerHTML = '';

            var deviceName = getCookieValue("CSDeviceName");
            engineName = getCookieValue("CABEngineName");
            document.getElementById('<%=lblCurrentDeviceName.ClientID%>').innerHTML = deviceName;

            var apiPath = CLOUDABISSCANR_BASE_API_URL;

            //Init CloudABIS Scanr
            CloudABISScanrInit(apiPath);
            var captureType = document.getElementById("captureType");
            captureType = captureType.options[captureType.selectedIndex].value;
            var quickScan = document.getElementById("quickScan");
            quickScan = quickScan.options[quickScan.selectedIndex].value;

            /*API Call*/
            if (engineName == EnumEnginesMapper.FingerPrint) {
                var captureParam = {
                    DeviceName: deviceName,
                    QuickScan: quickScan,
                    CaptureType: captureType,
                    SingleCaptureMode: EnumSingleCaptureMode.LeftFingerCapture,
                    CaptureTimeOut: 180.0,
                    CaptureOperationName: EnumCaptureOperationName.IDENTIFY,
                }
                FingerPrintCapture(captureParam, CaptureResult);
            }

            else if (engineName == EnumEnginesMapper.Iris) {
                var captureParam = {
                    DeviceName: deviceName,
                    QuickScan: quickScan,
                    FaceImage: EnumFeatureMode.Disable,
                    CaptureTimeOut: 180.0,
                    CaptureOperationName: EnumCaptureOperationName.IDENTIFY,
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
                    CaptureOperationName: EnumCaptureOperationName.IDENTIFY,
                }
                FaceCapture(captureParam, CaptureResult);
            } else if (engineName == EnumEnginesMapper.MultiModal) {

                var v12BaseAPI = getCookieValue("CABBaseURL");
                var v12ClientKey = getCookieValue("CABClientKey");
                var v12ClientAPIKey = getCookieValue("CABClientAPIKey");

                var fvBaseAPI = getCookieValue("FVBaseURL");
                var fvAppKey = getCookieValue("FVAppKey");
                var fvSecretKey = getCookieValue("FVSecretKey");
                var fvCustomerKey = getCookieValue("FVCustomerKey");

                var captureParam = {
                    OperationName: EnumMatchingOperationName.Identify,
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
          
            hideLoader();
            engineName = getCookieValue("CABEngineName");
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
                    document.getElementById('<%= serverResult.ClientID %>').innerHTML = "Capture success. Please click on identify button";
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
        <form id="form1" runat="server" class="commonForm identifyForm">
            <h1 class="headline">Identity</h1>
            <div class="mt-10">
                <label>Capture Type:</label>
                <select name="captureType" id="captureType">
                    <option value="SingleCapture">Single Capture</option>
                    <option value="DoubleCapture">Double Capture</option>
                </select>
            </div>
            <div class="mt-10">
                <label>Quick Scan:</label>
                <select name="quickScan" id="quickScan">
                    <option value="Enable">Enable</option>
                    <option value="Disable">Disable</option>
                </select>
            </div>
            <div id="loader" style="display: none;"></div>
            <div>
                <label id="lblCurrentDeviceTitle" class="currentDeviceCaption">Current Device Name:</label><asp:Label ID="lblCurrentDeviceName" runat="server" Text="..."></asp:Label>
                <input type="button" value="BioMetric Capture" onclick="captureBiometric()" />
                <asp:Button ID="btnSubmit" runat="server" Text="Identify" Enabled="true" Style="display: none" OnClick="btnIdentify_Click" Height="40px" />
                <asp:Button ID="Button1" runat="server" Text="Back" OnClick="BtnBack_Click" />
                &nbsp;<pre><asp:Label ID="serverResult" runat="server" Text="..."></asp:Label></pre>
                <asp:TextBox Width="350px" ID="fileStaveStatus" runat="server" Visible="false" TextMode="MultiLine" Text="Captured Template save at"></asp:TextBox>
                <asp:TextBox ID="bioImages" runat="server" CssClass="pagetitleValue" Style="display: none;" TextMode="MultiLine" Text="" Height="1000px" Width="1663px"></asp:TextBox>
            </div>
        </form>
    </div>
</body>
</html>


