﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modTipiSpese.aspx.cs" Inherits="modifica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tabella" runat="server">
                <tr>
                    <td>
                        <asp:TextBox ID="txtTipoSpesa" runat="server" CssClass="form-control border-light" Placeholder="Descrizione"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnCambia" runat="server" Text="Modifica" OnClick="btnCambia_Click" CssClass="btn btn-primary px-4" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
