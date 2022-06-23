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
        Marche m = new Marche();

        griglia.DataSource = m.SelectAll();
        griglia.DataBind();
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        // Controlli Formali
        if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Preparazione
        Marche m = new Marche(txtMarca.Text.Trim());

        //Controllo che la marca che andrò ad inserire non esista già
        if (m.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Marca già esistente')", true);
            return;
        }

        // Inserisco la nuova marca
        m.Insert();

        // Svuoto i campi  e aggiorno la griglia
        txtMarca.Text = "";
        griglia.DataSource = m.SelectAll();
        griglia.DataBind();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Marca Inserita')", true);
    }
}