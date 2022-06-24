<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InserisciTipiSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtTipoSpesa" runat="server" CssClass="form-control border-light" Placeholder="Descrizione"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnInserisci" runat="server" Text="Inserisci" OnClick="btnInserisci_Click" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-borderless bg-white">
            <Columns>
                <asp:BoundField DataField="descrizione" HeaderText="Descrizione" >
                <HeaderStyle CssClass="bg-dark text-white" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
</asp:Content>

