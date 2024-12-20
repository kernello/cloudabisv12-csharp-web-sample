﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudABISHome.aspx.cs" Inherits="CloudABISSampleWebApp.CloudABISHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome To CloudABIS v12 Web Application</title>
    <link href="Script/Style.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: ButtonHighlight">

    <div class="container">
        <form id="form1" runat="server">
            <div class="homeContainer">
                <h1 class="headline">Welcome To CloudABIS v12 Web Application</h1>
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkIsRegistered_Click">IsRegistered</asp:LinkButton>
                </div>
                <div>
                    <asp:LinkButton ID="LinkChangeID" runat="server" OnClick="lnkChangeID_Click">ChangeID</asp:LinkButton>
                </div>
                <div>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkDeleteID_Click">DeleteID</asp:LinkButton>
                </div>
                <div>
                    <asp:LinkButton ID="LinkRegister" runat="server" OnClick="lnkRegister_Click">Register</asp:LinkButton>
                </div>
                <div>
                    <asp:LinkButton ID="LinkIdentify" runat="server" OnClick="lnkIdentify_Click">Identify</asp:LinkButton>
                </div>
                <div>
                    <asp:LinkButton ID="LinkVerify" runat="server" OnClick="lnkVerify_Click">Verify</asp:LinkButton>
                </div>
                <div>
                    <asp:LinkButton ID="LinkUpdate" runat="server" OnClick="lnkUpdate_Click">Update</asp:LinkButton>
                </div>
                <div>
                    <asp:LinkButton ID="linkAuthenticate" runat="server" OnClick="lnkChangeActiveDevice_Click">Application Configuration</asp:LinkButton>
                </div>
                <div>
                    <pre><asp:Label ID="lblStatus" runat="server" Visible="true" Text="Server Status:"></asp:Label></pre>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
