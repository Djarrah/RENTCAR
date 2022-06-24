<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificaModelli.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control border-light" Placeholder="Descrizione"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtDescrizione" runat="server" CssClass="form-control border-light" Placeholder="Descrizione"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModifica" runat="server" Text="Modifica" OnClick="btnModifica_Click" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-borderless bg-white" OnSelectedIndexChanged="griglia_SelectedIndexChanged" DataKeyNames="codiceModello, codiceMarca">
                <Columns>
                    <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                    <asp:BoundField DataField="Modello" HeaderText="Modello" SortExpression="Modello" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn-block btn-dark" />
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True"/>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

