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
        CaricaGriglia();
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(txtTipoSpesa.Text))
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

        CaricaGriglia();

        txtTipoSpesa.Text = "";
    }

    protected void CaricaGriglia()
    {
        TipiSpese t = new TipiSpese();

        griglia.DataSource = t.SelectAll();
        griglia.DataBind();
    }
}