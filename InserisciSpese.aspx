<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InserisciSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlTipoSpesa" runat="server" DataTextField="descrizione" DataValueField="codiceTipoSpesa" CssClass="form-control border-light"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtImporto" runat="server" CssClass="form-control border-light" Placeholder="Importo"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtDataSpesa" runat="server" TextMode="Date" CssClass="form-control border-light"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnInvia" runat="server" Text="Inserisci" OnClick="btnInvia_Click" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-borderless bg-white">
                <Columns>
                    <asp:BoundField DataField="descrizione" HeaderText="Descrizione" />
                    <asp:BoundField DataField="dataSpesa" HeaderText="Data Spesa" />
                    <asp:BoundField DataField="importo" HeaderText="Importo" />
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

