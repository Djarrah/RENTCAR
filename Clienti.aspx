<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clienti.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnInserisci').click(function () {
                var url = '/forms/inserisci/insClienti.aspx';
                var dialog = $('<iframe src="' + url + '" frameborder="0"></iframe>').appendTo('body');

                dialog.dialog({
                    modal: true,
                    title: 'Inserimento dati',
                    overlay: {
                        opacity: 0.9,
                        background: 'black'
                    },

                    open: function (type, data) {
                        $(this).parent().appendTo('form');
                    }
                });

                return false;
            });

            $('#btnModifica').click(function () {
                var url = '/forms/modifica/modClienti.aspx';
                var dialog = $('<iframe src="' + url + '" frameborder="0"></iframe>').appendTo('body');

                dialog.dialog({
                    modal: true,
                    title: 'Modifica dati',
                    resizable: false,
                    width: '400px',
                    overlay: {
                        opacity: 0.9,
                        background: 'black'
                    },

                    open: function (type, data) {
                        $(this).parent().appendTo('form');
                    }
                });

                return false;
            });

        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <input type="button" id="btnInserisci" value="Inserisci" class="btn btn-primary px-4" />
                </td>
                <td>
                    <asp:Button ID="btnModifica" runat="server" Text="Modifica" CssClass="btn btn-primary px-4" ClientIDMode="Static" Enabled="False" />
                </td>
                <td>
                    <asp:Button ID="btnCaricaGriglia" runat="server" Text="Ricarica griglia" OnClick="btnCaricaGriglia_Click" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>
    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="griglia_SelectedIndexChanged" CssClass="table table-striped table-borderless bg-white" DataKeyNames="codiceCliente">
                <Columns>
                    <asp:BoundField DataField="codiceCliente" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="ragSociale" HeaderText="Ragione Sociale" />
                    <asp:BoundField DataField="pIVA" HeaderText="P.IVA" />
                    <asp:BoundField DataField="CF" HeaderText="CF"/>
                    <asp:BoundField DataField="indirizzo" HeaderText="Indirizzo" />
                    <asp:BoundField DataField="citta" HeaderText="Città" />
                    <asp:BoundField DataField="provincia" HeaderText="Pr."/>
                    <asp:BoundField DataField="cap" HeaderText="CAP" />
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn-block btn-dark"></asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>

