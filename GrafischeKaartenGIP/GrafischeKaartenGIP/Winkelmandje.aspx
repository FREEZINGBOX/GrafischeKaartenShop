<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Winkelmandje.aspx.cs" Inherits="GrafischeKaartenGIP.Winkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Winkelmandje</title>
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
        .auto-style2 {
            width: 1150px;
        }
        .auto-style6 {
            text-align: center;
        }
        .auto-style7 {
            text-align: center;
            width: 575px;
        }
        .auto-style8 {
            width: 1100px;
        }
        .auto-style9 {
            text-align: right;
        }
        .auto-style11 {
            width: 890px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>ONLINE GRAFISCHE KAARTEN SHOP - Winkelmandje</h2>
            <table class="auto-style1">
                <tr>
                    <td>Klantnummer:</td>
                    <td>
                        <asp:Label ID="lblKlantnummer" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Naam:</td>
                    <td>
                        <asp:Label ID="lblNaam" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Adres:</td>
                    <td>
                        <asp:Label ID="lblAdres" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblGemeente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Besteldatum:</td>
                    <td>
                        <asp:Label ID="lblBesteldatum" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvArtikelen" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvArtikelen_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="./images/VerwijderKnop.jpg" SelectText="" ShowSelectButton="True">
                    <ControlStyle Height="75px" Width="75px" />
                    <ItemStyle Width="100px" />
                    </asp:CommandField>
                    <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="./images/{0}" HeaderText="Foto">
                        <ControlStyle Height="175px" Width="230px" />
                        <ItemStyle Width="230px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="artikelnr" HeaderText="ArtNr">
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="naam" HeaderText="Naam">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="aantal" HeaderText="Aantal">
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="prijs" DataFormatString="{0:c}" HeaderText="Prijs">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="totaal" DataFormatString="{0:c}" HeaderText="Totaal">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
            <table class="auto-style8">
                <tr>
                    <td class="auto-style11">Totaal excl.:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblTotaalExcl" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">BTW:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblBTW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">Totaal incl:</td>
                    <td class="auto-style9">
                        <asp:Label ID="lblTotaalIncl" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table class="auto-style2">
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="btnBestellen" runat="server" Text="Bestellen..." OnClick="btnBestellen_Click" />
                </td>
                <td class="auto-style6">
                    <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar catalogus..." />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
