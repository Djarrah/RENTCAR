<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InserisciSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td><b>Tipo Spesa</b></td>
            <td><b>Importo</b></td>
            <td><b>Data Spesa</b></td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlTipoSpesa" runat="server" DataTextField="descrizione" DataValueField="codiceTipoSpesa"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtImporto" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtDataSpesa" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnInvia" runat="server" Text="Aggiungi Spesa" OnClick="btnInvia_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="descrizione" HeaderText="Descrizione" SortExpression="descrizione" />
                        <asp:BoundField DataField="dataSpesa" HeaderText="Data Spesa" SortExpression="dataSpesa" />
                        <asp:BoundField DataField="importo" HeaderText="Importo" SortExpression="importo" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

