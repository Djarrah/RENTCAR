using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inserimento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTipoSpesa.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        TipiSpese t = new TipiSpese(txtTipoSpesa.Text.Trim());

        if (t.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Tipo Spesa già esistente')", true);
            return;
        }

        t.Insert();

        txtTipoSpesa.Text = "";
        lbl.Text = "Tipo Spesa Inserito!";
    }
}