using System;
using System.Collections.Generic;
using System.Data;
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

            ddlMarche.DataSource = m.SelectAll();
            ddlMarche.DataTextField = "descrizione";
            ddlMarche.DataValueField = "codiceMarca";
            ddlMarche.DataBind();

            int codiceMarca = int.Parse(ddlMarche.SelectedValue);
            Modelli mo = new Modelli();
            DataTable dt = mo.SelectMarca(codiceMarca);
            if (dt.Rows.Count == 0)
            {
                ddlModelli.Enabled = false;
                return;
            }

            ddlModelli.DataSource = dt;
            ddlModelli.DataTextField = "descrizione";
            ddlModelli.DataValueField = "codiceModello";
            ddlModelli.DataBind();
        }
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        if (
            !ddlModelli.Enabled ||
            string.IsNullOrEmpty(txtTarga.Text) ||
            string.IsNullOrEmpty(txtData.Text) ||
            string.IsNullOrEmpty(txtCosto.Text) ||
            string.IsNullOrEmpty(txtPrezzo.Text)
            )
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        if (
            !decimal.TryParse(txtCosto.Text.Replace('.', ','), out decimal costo) ||
            !decimal.TryParse(txtPrezzo.Text.Replace('.', ','), out decimal prezzo)
            )
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        int codiceModello = int.Parse(ddlModelli.SelectedValue);
        string targa = txtTarga.Text.Trim().ToUpper();
        string dataAcquisto = txtData.Text;

        Auto a = new Auto(codiceModello, targa, dataAcquisto, costo, prezzo);

        if (a.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Voce già esistente')", true);
            return;
        }

        a.Insert();

        ddlMarche.SelectedIndex = 0;
        ddlModelli.Enabled = false;
        txtTarga.Text = "";
        txtData.Text = "";
        txtCosto.Text = "";
        txtPrezzo.Text = "";
        lbl.Text = "Voce Inserita!";
    }

    protected void ddlMarche_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlModelli.Enabled = true;
        int codiceMarca = int.Parse(ddlMarche.SelectedValue);

        Modelli m = new Modelli();
        DataTable dt = m.SelectMarca(codiceMarca);
        if (dt.Rows.Count == 0)
        {
            ddlModelli.Enabled = false;
            return;
        }

        ddlModelli.DataSource = dt;
        ddlModelli.DataTextField = "descrizione";
        ddlModelli.DataValueField = "codiceModello";
        ddlModelli.DataBind();
    }
}