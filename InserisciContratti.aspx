﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InserisciContratti.aspx.cs" Inherits="Default2" %>

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
                    <asp:Button ID="btnInvia" runat="server" Text="Inserisci" CssClass="btn btn-primary px-4" OnClick="btnInvia_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container-fluid">
            <asp:GridView ID="griglia" runat="server" CssClass="table table-striped table-borderless bg-white" AutoGenerateColumns="False" DataKeyNames="codiceContratto,codiceCliente,codiceAuto,codiceModello,codiceMarca">
                <Columns>
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
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>

