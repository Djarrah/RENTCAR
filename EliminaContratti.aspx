<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EliminaContratti.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtID" runat="server" Placeholder="ID" CssClass="form-control border-light"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnElimina" runat="server" Text="Elimina" CssClass="btn btn-primary px-4" OnClick="btnElimina_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container-fluid">
            <asp:GridView ID="griglia" runat="server" CssClass="table table-striped table-borderless bg-white" AutoGenerateColumns="False" OnSelectedIndexChanged="griglia_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="codiceContratto" HeaderText="ID"/>
                    <asp:BoundField DataField="ragSociale" HeaderText="Rag. Soc." SortExpression="ragSociale" />
                    <asp:BoundField DataField="pIVA" HeaderText="P.IVA" SortExpression="pIVA" />
                    <asp:BoundField DataField="CF" HeaderText="CF" SortExpression="CF" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                    <asp:BoundField DataField="Modello" HeaderText="Modello" SortExpression="Modello" />
                    <asp:BoundField DataField="targa" HeaderText="Targa" SortExpression="targa" />
                    <asp:BoundField DataField="prezzo" HeaderText="Prezzo" SortExpression="prezzo" />
                    <asp:BoundField DataField="dataInizioContratto" HeaderText="Inizio" ReadOnly="True" SortExpression="dataInizioContratto" />
                    <asp:BoundField DataField="dataTermineContratto" HeaderText="Termine" ReadOnly="True" SortExpression="dataTermineContratto" />
                    <asp:BoundField DataField="totContratto" HeaderText="Fatturato Previsto" />
                    <asp:BoundField DataField="totFatturato" HeaderText="Fatturato Corrente" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn-block btn-dark"/>
                </Columns>
                <SelectedRowStyle CssClass="text-white font-weight-bold bg-danger" Font-Bold="True"/>
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

