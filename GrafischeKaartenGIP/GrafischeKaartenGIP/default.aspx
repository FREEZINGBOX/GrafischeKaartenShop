<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrafischeKaartenGIP._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalogus</title>
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
        <div class="InhoudsDIV">
            <div class="CatalogusDIV">
            <asp:GridView ID="gvArtikelen" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvArtikelen_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="artikelnr" HeaderText="ArtNr">
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="naam" HeaderText="Naam">
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="./images/{0}" HeaderText="Foto">
                        <ControlStyle Height="140px" Width="200px" />
                        <ItemStyle Width="200px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="prijs" HeaderText="Verkoopprijs" DataFormatString="{0:c}">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="voorraad" HeaderText="Voorraad">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:CommandField SelectText="Voeg toe aan winkelmandje..." ShowSelectButton="True" ButtonType="Image" SelectImageUrl="./Images/VoegToeAanWinkelmand.JPG">
                    <ControlStyle Height="50px" Width="50px" />
                    <ItemStyle Width="100px" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
                <br />
                <asp:Button ID="btnGaWinkelmand" runat="server" OnClick="btnGaWinkelmand_Click" Text="Bekijk de inhoud van het winkelmandje..." />
            </div>
        </div>
    </form>
</body>
</html>
