<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modAuto.aspx.cs" Inherits="inserimento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-dark container-fluid py-3">
            <table id="tabella" runat="server">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlMarche" runat="server" OnSelectedIndexChanged="ddlMarche_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlModelli" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtTarga" runat="server" CssClass="form-control border-light" Placeholder="Targa" MaxLength="7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDataAcquisto" runat="server" CssClass="form-control border-light" ToolTip="Data Acquisto" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCosto" runat="server" CssClass="form-control border-light" Placeholder="Costo" MaxLength="9"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPrezzo" runat="server" CssClass="form-control border-light" Placeholder="Prezzo Mensile" MaxLength="7"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnModifica" runat="server" Text="Modifica" OnClick="btnModifica_Click" CssClass="btn btn-primary px-4" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
