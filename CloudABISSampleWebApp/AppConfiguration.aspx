<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppConfiguration.aspx.cs" Inherits="CloudABISSampleWebApp.AppConfiguration" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>CloudABIS Credentails</title>
    <link rel="Stylesheet" type="text/css" href="Script/Style.css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    <script src="Script/CloudABIS-ScanR.js"></script>
    <script src="Script/jquery-1.10.2.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {


            if (getCookieValue("CSDeviceName")) {
                var deviceName = getCookieValue("CSDeviceName");
                document.getElementById("deviceName").value = deviceName
                document.getElementById("engineDiv").style.display = 'block';
                var engineName = getEngineName(getCookieValue("CSDeviceName"));
                document.getElementById("engineName").innerHTML = engineName;
                if (engineName == EnumEnginesMapper.MultiModal) {
                    document.getElementById("divfv").style.display = 'block';
                }
            } else deviceName.options[deviceName.selectedIndex] = 0;

        });

        function setEngine() {

            var engineName = getEngineName(document.getElementById("deviceName").value);
            if (engineName) {
                document.getElementById("engineDiv").style.display = 'block';
                document.getElementById("engineName").innerHTML = engineName;

                if (engineName == EnumEnginesMapper.MultiModal) {
                    document.getElementById("divfv").style.display = 'block';
                } else {
                    document.getElementById("divfv").style.display = 'none';
                }
            } else document.getElementById("lblMessage").value = 'Please select a valid device name.';
        }
        function setConfiguration() {
            var engineName = document.getElementById("engineName").innerHTML;
            //engineName = engineName.options[engineName.selectedIndex].value;

            var deviceName = document.getElementById("deviceName");
            deviceName = deviceName.options[deviceName.selectedIndex].value;

            var baseURL = document.getElementById("txtAPIBaseURL").value;
            var clientKey = document.getElementById("txtClientKey").value;
            var clientAPIKey = document.getElementById("txtClientApiKey").value;

            var fvBaseURL = document.getElementById("txtFVAPIUrl").value;
            var fvAppKey = document.getElementById("txtFVAppKey").value;
            var fvSecretKey = document.getElementById("txtFVSecretKey").value;
            var fvCustomerKey = document.getElementById("txtFVCustomerKey").value;


            if (engineName != '') {
                //set credentials in cookey or any others client storage or get your storage
                setCookie("CSDeviceName", deviceName, 7);
                setCookie("CABEngineName", engineName, 7);

                setCookie("CABBaseURL", baseURL, 7);
                setCookie("CABClientKey", clientKey, 7);
                setCookie("CABClientAPIKey", clientAPIKey, 7);

                //FingerVein
                setCookie("FVBaseURL", fvBaseURL, 7);
                setCookie("FVAppKey", fvAppKey, 7);
                setCookie("FVSecretKey", fvSecretKey, 7);
                setCookie("FVCustomerKey", fvCustomerKey, 7);

                //window.location.href = "CloudABISHome.aspx";
                window.open("CloudABISHome.aspx", "_self");
            } else {
                failCall("Please put required values.");
            }
        }

        function failCall(status) {
            document.getElementById('lblMessage').innerHTML = status;
        }
    </script>

</head>
<body style="background-color: ButtonHighlight">
    <div class="formWrapper">
        <form id="form1" runat="server">
            <div class="iholder">
                <h1 class="headline">Application Configuration</h1>
                <fieldset class="ridge">
                    <label for="deviceName">Device Name</label>
                    <select id="deviceName" onchange="setEngine()">
                        <option value="Secugen">Secugen</option>
                        <option value="TwoPrintFutronic">TwoPrintFutronic</option>
                        <option value="TenPrintFutronic">TenPrintFutronic</option>
                        <option value="DigitalPersona">DigitalPersona</option>
                        <option value="TwoPrintWatsonMini">TwoPrintWatsonMini</option>
                        <option value="TenPrintWatsonMini">TenPrintWatsonMini</option>
                        <option value="Kojak">Kojak</option>
                        <option value="RealScanG10">RealScanG10</option>
                        <option value="EMX30">EMX30</option>
                        <option value="Face">Face</option>
                        <option value="TD100">TD100</option>
                        <option value="EF45">EF45</option>
                        <option value="IriTechBinocular">IriTechBinocular</option>
                        <option value="MultiModal">MultiModal</option>
                    </select>
                    <div id="engineDiv" style="display: none;">
                        <label for="lblEngine">Engine Name</label>
                        <label id="engineName"></label>
                    </div>
                    <%--   <select id="engineName">
                        <option value="FPFF02">FingerPrint</option>
                        <option value="IRIS01">Iris</option>
                        <option value="FACE01">Face</option>
                        <option value="MultiModal">MultiModal</option>
                    </select>--%>
                </fieldset>
                <div class="col-md-12">
                    <div id="divCloudABIS" class="col-md-6 float-left">
                        <fieldset class="ridge">
                            <legend>CloudABIS v12 Credentils</legend>
                            <div>

                                <div class="txtLebel">
                                    <label for="txtAPIBaseURL">AIP Base URL</label></br>
                    <asp:TextBox ID="txtAPIBaseURL" Width="100%" runat="server" Height="35px"></asp:TextBox>
                                </div>
                                <div class="txtLebel">
                                    <label for="txtClientKey">Client Key</label></br>
                    <asp:TextBox ID="txtClientKey" Width="100%" runat="server" Height="35px"></asp:TextBox>

                                </div>
                                <div class="txtLebel">
                                    <label for="txtClientApiKey">Client API Key</label></br>
                    <asp:TextBox ID="txtClientApiKey" Width="100%" runat="server" Height="35px"></asp:TextBox>
                                </div>
                        </fieldset>
                    </div>
                    <div id="divfv" class="col-md-6 float-right" style="display: none;">

                        <fieldset class="ridge">
                            <legend>FingerVein Credentils</legend>
                            <div class="txtLebel">
                                <label for="txtV10APIBaseURL">FingerVein API Base URL</label></br>
                    <asp:TextBox ID="txtFVAPIUrl" Width="100%" runat="server" Height="35px"></asp:TextBox>
                            </div>
                            <div class="txtLebel">
                                <label for="txtAppKey">App Key</label></br>
                    <asp:TextBox ID="txtFVAppKey" Width="100%" runat="server" Height="35px"></asp:TextBox>

                            </div>
                            <div class="txtLebel">
                                <label for="txtSecretKey">Secret Key</label></br>
                    <asp:TextBox ID="txtFVSecretKey" Width="100%" runat="server" Height="35px"></asp:TextBox>
                            </div>
                            <div class="txtLebel">
                                <label for="txtCustomerKey">Customer Key</label></br>
                    <asp:TextBox ID="txtFVCustomerKey" Width="100%" runat="server" Height="35px"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>
                </div>

                <fieldset class="ridge">
                    <input type="button" value="Save" onclick="setConfiguration()" />
                    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="BtnBack_Click" />
                    <label id="lblMessage"></label>
                </fieldset>
            </div>
        </form>
    </div>
</body>
</html>

