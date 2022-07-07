<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contabilita.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlAnno" runat="server" ToolTip="Anno di Fatturazione" CssClass="form-control border-light"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnCalcola" runat="server" Text="Calcola" CssClass="btn btn-primary px-4" OnClick="btnCalcola_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <table class="table table-striped table-borderless bg-white">
                <tr class="bg-dark text-white">
                    <th>Spese Annuali</th>
                    <th>Fatturato Annuale</th>
                    <th>Ricavi Annuali</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSpese" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFatturato" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblRicavi" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <asp:GridView ID="griglia" runat="server" CssClass="table table-striped table-borderless bg-white">
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>

            <%--<table class="table table-striped table-borderless bg-white">
                <tr class="bg-dark text-white">
                    <th>Mese</th>
                    <th>Fatturato</th>
                </tr>
                <asp:Literal ID="litTabellaMesi" runat="server"></asp:Literal>
            </table>--%>
        </div>
    </div>
</asp:Content>

