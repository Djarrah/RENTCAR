<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modContratti.aspx.cs" Inherits="modifica" %>

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
                        <asp:DropDownList ID="ddlClienti" runat="server" ToolTip="Cliente" CssClass="form-control border-light"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlAuto" runat="server" ToolTip="Auto" CssClass="form-control border-light"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDataInizio" runat="server" ToolTip="Inizio Contratto" CssClass="form-control border-light" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDataTermine" runat="server" ToolTip="Termine Contratto" CssClass="form-control border-light" TextMode="Date"></asp:TextBox>
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
