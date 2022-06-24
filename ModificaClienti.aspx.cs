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
        txtCitta.Text = riga[5].Text;
        txtProvincia.Text = riga[6].Text;
        txtCap.Text = riga[7].Text;
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
        string citta = txtCitta.Text.Trim();
        string provincia = txtProvincia.Text.Trim().ToUpper();
        string cap = txtCap.Text.Trim();

        // Controlli formali sui campi obbligatori
        if (
            string.IsNullOrEmpty(ragSociale) ||
            string.IsNullOrEmpty(indirizzo) ||
            string.IsNullOrEmpty(citta) ||
            string.IsNullOrEmpty(provincia) ||
            string.IsNullOrEmpty(cap)
            )
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
        Clienti c = new Clienti(codiceCliente, ragSociale, PIVA, CF, indirizzo, citta, provincia, cap);

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
        txtCitta.Text = "";
        txtProvincia.Text = "";
        txtCap.Text = "";

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successo", "alert('Cliente modificato')", true);
    }
}