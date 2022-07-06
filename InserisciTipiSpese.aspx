<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InserisciTipiSpese.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">

        $(document).ready(function () {

            $('#popup').click(function () {

                var url = 'inserimento.aspx';
                var pippo = $('<iframe src="' + url + '" frameborder="0"></iframe>').appendTo('body');

                pippo.dialog({
                    modal: true,
                    title: 'Inserimento dati',
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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="bg-dark container-fluid py-3">
        <table>
            <tr>
                <td>
                    <input type="button" id="popup" value="Inserisci" class="btn btn-primary px-4" />
                </td>
                <td>
                    <asp:Button ID="btnCaricaGriglia" runat="server" Text="Ricarica griglia" OnClick="btnCaricaGriglia_Click" CssClass="btn btn-primary px-4" />
                </td>
            </tr>
        </table>

    </div>

    <div class="bg-primary py-4">
        <div class="container">
            <asp:GridView ID="griglia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-borderless bg-white">
                <Columns>
                    <asp:BoundField DataField="descrizione" HeaderText="Descrizione"></asp:BoundField>
                </Columns>
                <HeaderStyle CssClass="bg-dark text-white" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

