<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GrafischeKaartenGIP._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>ONLINE GRAFISCHE KAARTEN SHOP - CATALOGUS</h2>
        <p>
            <asp:GridView ID="gvArtikelen" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="artikelnr" HeaderText="ArtNr">
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="naam" HeaderText="Naam">
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="./images/{0}" HeaderText="Foto">
                        <ControlStyle Height="125px" Width="250px" />
                        <ItemStyle Width="250px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="prijs" HeaderText="Verkoopprijs" DataFormatString="{0:c}">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="voorraad" HeaderText="Voorraad">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:CommandField SelectText="Voeg toe aan winkelmandje..." ShowSelectButton="True">
                    <ItemStyle Width="200px" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        </p>
    </form>
</body>
</html>
