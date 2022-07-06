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
            TipiSpese t = new TipiSpese();

            ddlTipiSpese.DataSource = t.SelectAll();
            ddlTipiSpese.DataValueField = "codiceTipoSpesa";
            ddlTipiSpese.DataTextField = "descrizione";
            ddlTipiSpese.DataBind();
        }
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtDataSpesa.Text) || string.IsNullOrEmpty(txtImporto.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        if (!decimal.TryParse(txtImporto.Text.Replace('.', ','), out decimal importo))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        int codiceTipoSpesa = int.Parse(ddlTipiSpese.SelectedValue);
        string dataSpesa = txtDataSpesa.Text;

        Spese s = new Spese(codiceTipoSpesa, importo, dataSpesa);
        s.Insert();

        ddlTipiSpese.SelectedIndex = 0;
        txtImporto.Text = "";
        txtDataSpesa.Text = "";
        lbl.Text = "Spesa Inserita!";
    }
}