<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GrafischeKaartenGIP.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
        .auto-style2 {
            width: 179px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>ONLINE GRAFISCHE KAARTEN SHOP - LOGIN</h2>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Gebruikersnaam:</td>
                <td>
                    <asp:TextBox ID="txtGebruikersnaam" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvGebruikersnaam" runat="server" ControlToValidate="txtGebruikersnaam" ErrorMessage="*Verplicht veld" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Wachtwoord</td>
                <td>
                    <asp:TextBox ID="txtWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvWachtwoord" runat="server" ControlToValidate="txtWachtwoord" ErrorMessage="*Verplicht veld" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnAanmelden" runat="server" OnClick="btnAanmelden_Click" Text="Aanmelden" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblUitvoer" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
