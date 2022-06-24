<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificaTipiSpese.aspx.cs" Inherits="Default2" %>

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
                    <asp:Button ID="btnCambia" runat="server" Text="Cambia" OnClick="btnCambia_Click" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="griglia_SelectedIndexChanged" CssClass="table table-striped table-borderless bg-white" DataKeyNames="codiceTipoSpesa">
                <Columns>
                    <asp:BoundField DataField="codiceTipoSpesa" HeaderText="ID" SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="descrizione" HeaderText="Descrizione" SortExpression="descrizione" />
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn-block btn-dark"></asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True"/>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

