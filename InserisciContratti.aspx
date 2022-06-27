<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InserisciContratti.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlClienti" runat="server" CssClass="form-control border-light"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAuto" runat="server" CssClass="form-control border-light"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtDataInizio" runat="server" TextMode="Date" ToolTip="Data Inizio Contratto" CssClass="form-control border-light"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtDataTermine" runat="server" TextMode="Date" ToolTip="Data Termine Contratto" CssClass="form-control border-light"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCosto" runat="server" Placeholder="Costo" CssClass="form-control border-light"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPrezzo" runat="server" Placeholder="Prezzo" CssClass="form-control border-light"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnInvia" runat="server" Text="Inserisci" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container-fluid">
            <asp:GridView ID="griglia" runat="server" CssClass="table table-striped table-borderless bg-white" AutoGenerateColumns="False" DataKeyNames="codiceContratto,codiceCliente,codiceAuto,codiceModello,codiceMarca">
                <Columns>
                    <asp:BoundField DataField="codiceContratto" HeaderText="codiceContratto" InsertVisible="False" ReadOnly="True" SortExpression="codiceContratto" Visible="False" />
                    <asp:BoundField DataField="codiceCliente" HeaderText="codiceCliente" InsertVisible="False" ReadOnly="True" SortExpression="codiceCliente" Visible="False" />
                    <asp:BoundField DataField="codiceAuto" HeaderText="codiceAuto" InsertVisible="False" ReadOnly="True" SortExpression="codiceAuto" Visible="False" />
                    <asp:BoundField DataField="codiceModello" HeaderText="codiceModello" InsertVisible="False" ReadOnly="True" SortExpression="codiceModello" Visible="False" />
                    <asp:BoundField DataField="codiceMarca" HeaderText="codiceMarca" InsertVisible="False" ReadOnly="True" SortExpression="codiceMarca" Visible="False" />
                    <asp:BoundField DataField="ragSociale" HeaderText="Rag. Soc." SortExpression="ragSociale" />
                    <asp:BoundField DataField="pIVA" HeaderText="IVA" SortExpression="pIVA" />
                    <asp:BoundField DataField="CF" HeaderText="CF" SortExpression="CF" />
                    <asp:BoundField DataField="indirizzo" HeaderText="Indirizzo" SortExpression="indirizzo" />
                    <asp:BoundField DataField="cap" HeaderText="CAP" SortExpression="cap" />
                    <asp:BoundField DataField="citta" HeaderText="Città" SortExpression="citta" />
                    <asp:BoundField DataField="provincia" HeaderText="Provincia" SortExpression="provincia" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                    <asp:BoundField DataField="Modello" HeaderText="Modello" SortExpression="Modello" />
                    <asp:BoundField DataField="targa" HeaderText="Targa" SortExpression="targa" />
                    <asp:BoundField DataField="costo" HeaderText="Costo" SortExpression="costo" />
                    <asp:BoundField DataField="dataInizioContratto" HeaderText="Inizio" ReadOnly="True" SortExpression="dataInizioContratto" />
                    <asp:BoundField DataField="dataTermineContratto" HeaderText="Termine" ReadOnly="True" SortExpression="dataTermineContratto" />
                    <asp:BoundField DataField="prezzo" HeaderText="Prezzo" SortExpression="prezzo" />
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>

