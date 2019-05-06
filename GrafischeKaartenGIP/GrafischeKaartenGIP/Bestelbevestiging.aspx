<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bestelbevestiging.aspx.cs" Inherits="GrafischeKaartenGIP.Bestelbevestiging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bestelbevestiging
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>ONLINE GRAFISCHE KAARTEN SHOP - Bestelbevestiging</h2>
            <p>
                Uw bestelling met ordernummer&nbsp;<asp:Label ID="lblOrdernr" runat="server" Font-Bold="True"></asp:Label>
&nbsp;werd door ons goed ontvangen.</p>
            <p>
                Na betaling van op
                <asp:Label ID="lblBedrag" runat="server" Font-Bold="True"></asp:Label>
&nbsp;rekeningnummer <strong>BE36 1030 5325 4381</strong> zullen wij overgaan tot de verzending van de grafische kaarten.</p>
            <p>
                Gelieve het ordernummer als betalingsreferentie mee te geven.</p>
            <p>
                Bedankt voor uw vertrouwen!</p>
            <p>
                <asp:Button ID="btnCatalogus" runat="server" Text="Terug naar catalogus..." />
            </p>
        </div>
    </form>
</body>
</html>
