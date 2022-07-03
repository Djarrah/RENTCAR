<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modSpese.aspx.cs" Inherits="modifica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl" runat="server"></asp:Label>
            <table id="tabella" runat="server">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlTipiSpese" runat="server" CssClass="form-control border-light" ToolTip="Tipo Spesa"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtImporto" runat="server" CssClass="form-control border-light" Placeholder="Importo"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDataSpesa" runat="server" CssClass="form-control border-light" Placeholder="Data" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCambia" runat="server" Text="Modifica" OnClick="btnCambia_Click" CssClass="btn btn-primary px-4" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
