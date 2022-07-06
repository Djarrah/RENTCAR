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
        if (!IsPostBack)
        {
            Marche m = new Marche();

            ddl.DataSource = m.SelectAll();
            ddl.DataTextField = "descrizione";
            ddl.DataValueField = "codiceMarca";
            ddl.DataBind();
        }
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        Modelli m = new Modelli(int.Parse(ddl.SelectedValue), txt.Text.Trim());

        if (m.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Voce già esistente')", true);
            return;
        }

        m.Insert();

        txt.Text = "";
        ddl.SelectedIndex = 0;
        lbl.Text = "Voce Inserita!";
    }
}