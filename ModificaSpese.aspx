<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificaSpese.aspx.cs" Inherits="Default2" %>

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
                    <asp:TextBox ID="txtData" runat="server" TextMode="Date" CssClass="form-control border-light"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModifica" runat="server" Text="Modifica" OnClick="btnModifica_Click" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="griglia_SelectedIndexChanged" DataKeyNames="codiceSpesa,codiceTipoSpesa" CssClass="table table-striped table-borderless bg-white">
                <Columns>
                    <asp:BoundField DataField="codiceSpesa" HeaderText="codiceSpesa" InsertVisible="False" ReadOnly="True" SortExpression="codiceSpesa" Visible="False" />
                    <asp:BoundField DataField="codiceTipoSpesa" HeaderText="codiceTipoSpesa" SortExpression="codiceTipoSpesa" InsertVisible="False" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="descrizione" HeaderText="Descrizione" SortExpression="descrizione" />
                    <asp:BoundField DataField="importo" HeaderText="Importo" SortExpression="importo" />
                    <asp:BoundField DataField="dataSpesa" HeaderText="Data" ReadOnly="True" SortExpression="dataSpesa" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn-block btn-dark" />
                </Columns>
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True"/>
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
