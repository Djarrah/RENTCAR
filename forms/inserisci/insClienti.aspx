<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insClienti.aspx.cs" Inherits="inserimento" %>

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
                        <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtRagSoc" runat="server" CssClass="form-control border-light" Placeholder="Ragione Sociale"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPIVA" runat="server" CssClass="form-control border-light" Placeholder="P.IVA"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCF" runat="server" CssClass="form-control border-light" Placeholder="CF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtIndirizzo" runat="server" CssClass="form-control border-light" Placeholder="Indirizzo"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCitta" runat="server" CssClass="form-control border-light" Placeholder="Città"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control border-light" Placeholder="Pr." MaxLength="2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCAP" runat="server" CssClass="form-control border-light" Placeholder="CAP" MaxLength="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnInserisci" runat="server" Text="Inserisci" OnClick="btnInserisci_Click" CssClass="btn btn-primary px-4" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
