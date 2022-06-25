<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EliminaSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtCodiceSpesa" runat="server" CssClass="form-control border-light" Placeholder="ID"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" CssClass="btn btn-primary px-4"/>
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="griglia_SelectedIndexChanged" CssClass="table table-striped table-borderless bg-white">
                <Columns>
                    <asp:BoundField DataField="codiceSpesa" HeaderText="ID" />
                    <asp:BoundField DataField="descrizione" HeaderText="Tipo Spesa" SortExpression="descrizione" />
                    <asp:BoundField DataField="importo" HeaderText="Importo" SortExpression="importo" />
                    <asp:BoundField DataField="dataSpesa" HeaderText="Data" ReadOnly="True" SortExpression="dataSpesa" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn-block btn-dark"/>
                </Columns>
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True"/>
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

