using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Clienti c = new Clienti();

        griglia.DataSource = c.SelectAll();
        griglia.DataBind();
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        TableCellCollection riga = griglia.SelectedRow.Cells;

        txtRagSoc.Text = riga[1].Text;
        txtPIVA.Text = riga[2].Text.Replace("&nbsp;", ""); // Rimpiazzo gli spazi vuoti del db con stringhe vuote
        txtCF.Text = riga[3].Text.Replace("&nbsp;", "");
        txtIndirizzo.Text = riga[4].Text;
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        // Controllo che una riga sia selezionata
        if (griglia.SelectedRow == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Selezionare una voce')", true);
            return;
        }

        // Dichiarazioni variabili
        int codiceCliente = (int)griglia.SelectedDataKey[0];
        string ragSociale = txtRagSoc.Text.Trim();
        string PIVA = txtPIVA.Text.Trim();
        string CF = txtCF.Text.Trim();
        string indirizzo = txtIndirizzo.Text.Trim();

        // Controlli formali sui campi obbligatori
        if (string.IsNullOrEmpty(ragSociale) || string.IsNullOrEmpty(indirizzo))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // L' utente deve inserire almeno uno dei due campi tra PIVA e CF
        if (string.IsNullOrEmpty(PIVA) && string.IsNullOrEmpty(CF))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // Configurazione elementi connessione
        Clienti c = new Clienti(codiceCliente, ragSociale, PIVA, CF, indirizzo);

        // Controllo ridondanza
        if (c.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati ridondanti')", true);
            return;
        }

        // Modifica record
        c.Update();

        // Operazioni di cleanup
        griglia.DataSource = c.SelectAll();
        griglia.DataBind();
        griglia.SelectedIndex = 0;

        txtRagSoc.Text = "";
        txtPIVA.Text = "";
        txtCF.Text = "";
        txtIndirizzo.Text = "";

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successo", "alert('Cliente modificato')", true);
    }
}