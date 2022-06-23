﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EliminaSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtCodiceSpesa" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="griglia_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="codiceSpesa" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="codiceSpesa" />
                        <asp:BoundField DataField="descrizione" HeaderText="Tipo Spesa" SortExpression="descrizione" />
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

