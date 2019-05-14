<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Toevoegen.aspx.cs" Inherits="GrafischeKaartenGIP.Toevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Toevoegen</title>
    <style type="text/css">
        .auto-style1 {
            width: 1000px;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            width: 400px;
        }
    </style>
</head>
<body class="achtergrond">
    <form id="form1" runat="server">
        <link href="Opmaak.css" rel="stylesheet" />
        <div class="BannerDIV">
            <script id="tui-e0z8">(function(t){t.e0z8={"id":"2138b4b7jy2m6mp3", 
                "size":"1000x75"}}(window.tweenui=window.tweenui||{}))</script> 
            <script src="https://s3-eu-west-1.amazonaws.com/display.tweenui.com/v.js" async></script><noscript> 
            <iframe src="//s.tuicdn.com/i/2138b4b7/jy2m6mp3.html" width="1000" height="75"></iframe></noscript>
        </div>

        <div class="InhoudsDiv">
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Image ID="imgFoto" runat="server" Height="300px" Width="450px" />
                    </td>
                    <td class="auto-style2">
                        <table class="auto-style3">
                            <tr>
                                <td>ArtNr:</td>
                                <td>
                                    <asp:Label ID="lblArtNr" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Naam:</td>
                                <td>
                                    <asp:Label ID="lblNaam" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Verkoopprijs:</td>
                                <td>
                                    <asp:Label ID="lblVerkoopprijs" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Voorraad:</td>
                                <td>
                                    <asp:Label ID="lblVoorraad" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblFout" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblAantal" runat="server" Text="Aantal te bestellen exemplaren van dit item:"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtAantal" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="btnVoegToe" runat="server" OnClick="btnVoegToe_Click" Text="Voeg toe aan mandje..." />
            <br />
            <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar catalogus..." Visible="False" />
            </div>
    </form>
</body>
</html>
