<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificaSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Tipo"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Importo"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Data"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlTipoSpesa" runat="server" DataTextField="descrizione" DataValueField="codiceTipoSpesa"></asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtImporto" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtData" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnModifica" runat="server" Text="Modifica" OnClick="btnModifica_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="griglia_SelectedIndexChanged" DataKeyNames="codiceSpesa,codiceTipoSpesa">
                    <Columns>
                        <asp:BoundField DataField="codiceSpesa" HeaderText="codiceSpesa" InsertVisible="False" ReadOnly="True" SortExpression="codiceSpesa" Visible="False" />
                        <asp:BoundField DataField="codiceTipoSpesa" HeaderText="codiceTipoSpesa" SortExpression="codiceTipoSpesa" InsertVisible="False" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="descrizione" HeaderText="Descrizione" SortExpression="descrizione" />
                        <asp:BoundField DataField="importo" HeaderText="Importo" SortExpression="importo" />
                        <asp:BoundField DataField="dataSpesa" HeaderText="Data" ReadOnly="True" SortExpression="dataSpesa" />
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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

