<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinkelmandjeLeeg.aspx.cs" Inherits="GrafischeKaartenGIP.WinkelmandjeLeeg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leeg Winkelmandje</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>ONLINE GRAFISCHE KAARTEN SHOP - Winkelmandje</h2>
            <p>
                &nbsp;</p>
            <p>
                Het winkelmandje is leeg. Klik op de knop om terug te keren naar de catalogus.</p>
            <p>
                <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar de catalogus..." />
            </p>
        </div>
    </form>
</body>
</html>
