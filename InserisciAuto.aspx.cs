using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CaricaGriglia();

        if (!IsPostBack)
        {
            Modelli m = new Modelli();

            ddlModelli.DataSource = m.SelectForDDL();
            ddlModelli.DataValueField = "codiceModello";
            ddlModelli.DataTextField = "Modello";
            ddlModelli.DataBind();
        }
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        // Controlli formali
        if (
            string.IsNullOrEmpty(txtTarga.Text) ||
            string.IsNullOrEmpty(txtDataAcquisto.Text) ||
            string.IsNullOrEmpty(txtCosto.Text) ||
            string.IsNullOrEmpty(txtPrezzo.Text)
            )
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        if (!decimal.TryParse(txtCosto.Text, out decimal res) || !decimal.TryParse(txtPrezzo.Text, out decimal res2))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Creazioni variabili
        int codiceModello = int.Parse(ddlModelli.SelectedValue);
        string targa = txtTarga.Text.Trim().ToUpper();
        string dataAcquisto = txtDataAcquisto.Text;
        string costo = txtCosto.Text.Trim().Replace(',', '.');
        string prezzo = txtPrezzo.Text.Trim().Replace(',', '.');

        Auto a = new Auto(codiceModello, targa, dataAcquisto, costo, prezzo);

        // Controllo ridondanza
        if (a.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Targa già esistente')", true);
            return;
        }

        // Inserimento
        a.Insert();

        // Pulizia
        ddlModelli.SelectedIndex = 0;
        txtTarga.Text = "";
        txtDataAcquisto.Text = "";
        txtCosto.Text = "";
        txtPrezzo.Text = "";

        CaricaGriglia();
    }

    protected void CaricaGriglia()
    {
        Auto a = new Auto();

        griglia.DataSource = a.SelectAll();
        griglia.DataBind();
    }
}