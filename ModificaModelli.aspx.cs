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
            
            ddlMarca.DataSource = ma.SelectAll();
            ddlMarca.DataTextField = "descrizione";
            ddlMarca.DataValueField = "codiceMarca";
            ddlMarca.DataBind();
        }
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMarca.SelectedValue = griglia.SelectedDataKey[1].ToString();
        txtDescrizione.Text = griglia.SelectedRow.Cells[1].Text;
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        // Controlli formali
        if (griglia.SelectedRow == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Selezionare una spesa')", true);
            return;
        }

        if (string.IsNullOrEmpty(txtDescrizione.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Creo i parametri per le query
        int codiceModello = (int)griglia.SelectedDataKey[0];
        int codiceMarca = int.Parse(ddlMarca.SelectedValue);
        string descrizione = txtDescrizione.Text.Trim();

        Modelli m = new Modelli(codiceModello, codiceMarca, descrizione);

        // Verifico la presenza di duplicati
        if (m.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Modello già presente')", true);
            return;
        }

        // Modifico il record nel db
        m.Update();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Modello modificato')", true);

        // Eseguo le operazioni di aggiornamento e pulizia
        griglia.DataSource = m.SelectAll();
        griglia.DataBind();
        griglia.SelectedIndex = 0;

        ddlMarca.SelectedIndex = 0;

        txtDescrizione.Text = "";
    }
}