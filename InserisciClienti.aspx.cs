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

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        // Dichiarazioni variabili
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

        // Creare l' oggetto per l'interazione col database
        Clienti c = new Clienti(ragSociale, PIVA, CF, indirizzo, citta, provincia, cap);

        // Verifica record ridondanti per CF e PIVA
        if (c.CheckOne() == true)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati ridondanti')", true);
            return;
        }

        // Procedo con l'Inserimento
        c.Insert();

        // Pulizia campi e aggiornamento tabella
        griglia.DataSource = c.SelectAll();
        griglia.DataBind();

        txtRagSoc.Text = "";
        txtPIVA.Text = "";
        txtCF.Text = "";
        txtIndirizzo.Text = "";
        txtCitta.Text = "";
        txtProvincia.Text = "";
        txtCap.Text = "";

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successo", "alert('Inserimenti avvenuto con successo')", true);
    }
}