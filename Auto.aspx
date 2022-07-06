<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Auto.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnInserisci').click(function () {
                var url = '/forms/inserisci/insAuto.aspx';
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
                var url = '/forms/modifica/modAuto.aspx';
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
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="griglia_SelectedIndexChanged" CssClass="table table-striped table-borderless bg-white" DataKeyNames="codiceAuto">
                <Columns>
                    <asp:BoundField DataField="codiceAuto" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                    <asp:BoundField DataField="Modello" HeaderText="Modello" SortExpression="Modello" />
                    <asp:BoundField DataField="targa" HeaderText="Targa" SortExpression="Targa" />
                    <asp:BoundField DataField="dataAcquisto" HeaderText="Data Acquisto" SortExpression="dataAcquisto" />
                    <asp:BoundField DataField="costo" HeaderText="Costo" SortExpression="costo" />
                    <asp:BoundField DataField="prezzo" HeaderText="Prezzo Mensile" SortExpression="prezzo" />
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn-block btn-dark"></asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
                <SelectedRowStyle CssClass="bg-success text-white font-weight-bold" Font-Bold="True" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>

