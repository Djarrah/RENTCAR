<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificaTipiSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtTipoSpesa" runat="server"></asp:TextBox>
    <asp:Button ID="btnCambia" runat="server" Text="Cambia" OnClick="btnCambia_Click" />

    <%-- Nascondere colonna id? --%>
    <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="griglia_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="codiceTipoSpesa" HeaderText="Codice" InsertVisible="False" ReadOnly="True" SortExpression="codiceTipoSpesa" />
            <asp:BoundField DataField="descrizione" HeaderText="Descrizione" SortExpression="descrizione" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
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
</asp:Content>

