<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Toevoegen.aspx.cs" Inherits="GrafischeKaartenGIP.Toevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1200px;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>ONLINE GRAFISCHE KAARTEN SHOP - Item toevoegen aan winkelmandje</h2>
            <table class="auto-style1">
                <tr>
                    <td>
                        <img alt="" height="400px" src="" width="650px" /></td>
                    <td class="auto-style2">
                        <asp:DataList ID="DataList1" runat="server">
                            <ItemTemplate>
                                <table class="auto-style3">
                                    <tr>
                                        <td>ArtNr:</td>
                                        <td>
                                            <asp:Label ID="lblArtNr" runat="server" Text='<%# bind("artikelnr") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Naam:</td>
                                        <td>
                                            <asp:Label ID="lblNaam" runat="server" Text='<%# bind("naam") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Verkoopprijs:</td>
                                        <td>
                                            <asp:Label ID="lblPrijs" runat="server" Text='<%# bind("prijs") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Voorraad:</td>
                                        <td>
                                            <asp:Label ID="lblvoorraad" runat="server" Text='<%# bind("voorraad") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
