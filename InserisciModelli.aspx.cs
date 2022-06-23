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
        Modelli mo = new Modelli();

        griglia.DataSource = mo.SelectAll();
        griglia.DataBind();

        if (!IsPostBack)
        {
            Marche ma = new Marche();

            ddlMarche.DataSource = ma.SelectAll();
            ddlMarche.DataBind();
        }
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        // Controlli formali
        if (string.IsNullOrEmpty(txtDescrizione.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Dichiarazione variabili
        int codiceMarca = int.Parse(ddlMarche.SelectedValue);
        string descrizione = txtDescrizione.Text.Trim();

        Modelli m = new Modelli(codiceMarca, descrizione);

        // Controllo Duplicati

        if (m.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Modello già esistente')", true);
            return;
        }

        // Inserimento del nuovo record
        m.Insert();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Modello Inserito')", true);

        // Pulizia campi e aggiornamento tabella
        griglia.DataSource = m.SelectAll();
        griglia.DataBind();
        
        ddlMarche.SelectedIndex = 0;
        txtDescrizione.Text = "";
    }
}