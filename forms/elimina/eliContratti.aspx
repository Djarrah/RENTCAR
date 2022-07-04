<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eliContratti.aspx.cs" Inherits="forms_elimina_eliSpese" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
        <div id="tabella" runat="server">
            <p>Sei sicuro di voler eliminare il contratto selezionato?</p>
            <asp:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" />
        </div>
    </form>
</body>
</html>
