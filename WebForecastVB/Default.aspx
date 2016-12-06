<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebForecastVB._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Voorspelling van realisatiegraad cursus</title>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="Style/css/bootstrap.css" rel="stylesheet" />
    <script src="Style/js/bootstrap.js"></script>
    <link href="Style/css/style.css" rel="stylesheet" />
    <script src="Style/js/script.js"></script>
</head>
<body class="container">
    <form id="form1" runat="server">
    <div>
    <h1>Voorspelling van realisatiegraad cursus</h1>
        <table class="table">
            <tr>
                <td>Opleidingsnummer</td>
                <td>
                 <div class="input-group">
                    <asp:TextBox ID="txtOpleidingsnummer" placeholder="123456" runat="server" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                     <asp:Button ID="btnGetOpleiding" runat="server" Text="GET" CssClass="btn " />
                    </span>
                </div>

                </td>
            </tr>
            <tr>
                <td>Merk</td>
                <td>
                    <asp:DropDownList ID="ddlMerk" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Uitvoerend centrum</td>
                <td>
                    <asp:DropDownList ID="ddlCentrum" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>SubAfdeling</td>
                <td>
                    <asp:DropDownList ID="ddlSubAfd" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Start van de cursus</td>
                <td>
                    <asp:TextBox ID="txtDatum" runat="server" CssClass="form-control" placeholder="31/12/2016"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>% valt tussen bereik</td>
                <td>
                    <asp:DropDownList ID="ddlValttussen" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnBeterken" runat="server" Text="Bereken" CssClass="btn btn-default btn-lg btn-block" />
        <asp:Label ID="lblRealisatie" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtTotaal" runat="server" CssClass="form-control btn-block"></asp:TextBox>
    </div>
    </form>
</body>
</html>
