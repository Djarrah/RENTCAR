﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InserisciClienti.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table>
        <tr>
            <th>Ragione Sociale</th>
            <th>P.IVA</th>
            <th>CF</th>
            <th>Indirizzo</th>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtRagSoc" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPIVA" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCF" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtIndirizzo" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnInserisci" runat="server" Text="Inserisci" OnClick="btnInserisci_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="codiceCliente" HeaderText="codiceCliente" InsertVisible="False" ReadOnly="True" SortExpression="codiceCliente" Visible="False" />
                        <asp:BoundField DataField="ragSociale" HeaderText="Ragione Sociale" SortExpression="ragSociale" />
                        <asp:BoundField DataField="pIVA" HeaderText="P.IVA" SortExpression="pIVA" />
                        <asp:BoundField DataField="CF" HeaderText="CF" SortExpression="CF" />
                        <asp:BoundField DataField="indirizzo" HeaderText="Indirizzo" SortExpression="indirizzo" />
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

