<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificaClienti.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="bg-dark container-fluid py-3">

        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtRagSoc" runat="server" CssClass="form-control border-light" Placeholder="Ragione Sociale"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPIVA" runat="server" CssClass="form-control border-light" Placeholder="P. IVA"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCF" runat="server" CssClass="form-control border-light" Placeholder="CF"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtIndirizzo" runat="server" CssClass="form-control border-light" Placeholder="Indirizzo"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCitta" runat="server" CssClass="form-control border-light" Placeholder="Città"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtProvincia" runat="server" MaxLength="2" CssClass="form-control border-light" Placeholder="Provincia"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCap" runat="server" MaxLength="5" CssClass="form-control border-light" Placeholder="CAP"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModifica" runat="server" Text="Modifica" OnClick="btnModifica_Click" CssClass="btn btn-primary px-4 btn-block" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" DataKeyNames="codiceCliente" OnSelectedIndexChanged="griglia_SelectedIndexChanged" CssClass="table table-striped table-borderless bg-white">
                <Columns>
                    <asp:BoundField DataField="codiceCliente" HeaderText="codiceCliente" InsertVisible="False" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="ragSociale" HeaderText="Ragione Sociale" />
                    <asp:BoundField DataField="pIVA" HeaderText="P.IVA" />
                    <asp:BoundField DataField="CF" HeaderText="CF" />
                    <asp:BoundField DataField="indirizzo" HeaderText="Indirizzo" />
                    <asp:BoundField DataField="citta" HeaderText="Città" />
                    <asp:BoundField DataField="provincia" HeaderText="Provincia" />
                    <asp:BoundField DataField="cap" HeaderText="CAP" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn-block btn-dark" />
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

