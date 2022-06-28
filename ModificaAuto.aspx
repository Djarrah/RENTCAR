<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificaAuto.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlModelli" runat="server" CssClass="form-control border-light" ></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtTarga" runat="server" MaxLength="7" CssClass="form-control border-light" Placeholder="Targa"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtDataAcquisto" runat="server" TextMode="Date" CssClass="form-control border-light" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCosto" runat="server" MaxLength="9" CssClass="form-control border-light" Placeholder="Costo"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPrezzo" runat="server" MaxLength="7" CssClass="form-control border-light" Placeholder="Prezzo"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModifica" runat="server" Text="Modifica" CssClass="btn btn-primary px-4" OnClick="btnModifica_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" CssClass="table table-striped table-borderless bg-white" AutoGenerateColumns="False" DataKeyNames="codiceAuto, codiceMarca, codiceModello" OnSelectedIndexChanged="griglia_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="codiceAuto" HeaderText="codiceAuto" Visible="False" />
                    <asp:BoundField DataField="codiceMarca" HeaderText="codiceMarca" Visible="False" />     
                    <asp:BoundField DataField="codiceModello" HeaderText="codiceModello" Visible="False" />    
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Modello" HeaderText="Modello" />
                    <asp:BoundField DataField="targa" HeaderText="Targa" />
                    <asp:BoundField DataField="dataAcquisto" HeaderText="Data Acquisto" />
                    <asp:BoundField DataField="costo" HeaderText="Costo" />
                    <asp:BoundField DataField="prezzo" HeaderText="Prezzo" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn-block btn-dark"/>
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True"/>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

