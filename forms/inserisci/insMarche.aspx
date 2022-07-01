<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insMarche.aspx.cs" Inherits="inserimento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-dark container-fluid py-3">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txt" runat="server" CssClass="form-control border-light" Placeholder="Descrizione"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnInserisci" runat="server" Text="Inserisci" OnClick="btnInserisci_Click" CssClass="btn btn-primary px-4" />
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
