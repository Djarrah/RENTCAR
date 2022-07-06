using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
            if (Session["cod"] == null)
            {
                lbl.Text = "ERRORE, selezionare una voce";
                tabella.Visible = false;

                return;
            }

            int cod = int.Parse(Session["cod"].ToString());
            Auto a = new Auto(cod);
            DataRow sel = a.SelectOne().Rows[0];
            txtTarga.Text = sel["targa"].ToString();
            txtDataAcquisto.Text = sel.Field<DateTime>(4).ToString("yyyy-MM-dd");
            txtCosto.Text = sel["costo"].ToString();
            txtPrezzo.Text = sel["prezzo"].ToString();

            Marche m = new Marche();
            ddlMarche.DataSource = m.SelectAll();
            ddlMarche.DataTextField = "descrizione";
            ddlMarche.DataValueField = "codiceMarca";
            ddlMarche.DataBind();

            int codiceMarca = int.Parse(sel["codiceMarca"].ToString());
            ddlMarche.SelectedValue = codiceMarca.ToString();

            Modelli mo = new Modelli();
            DataTable dt = mo.SelectMarca(codiceMarca);

            ddlModelli.DataSource = dt;
            ddlModelli.DataTextField = "descrizione";
            ddlModelli.DataValueField = "codiceModello";
            ddlModelli.DataBind();
            ddlModelli.SelectedValue = sel["codiceModello"].ToString();
        }
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        // Se non vi è nessun elemento selezionato impedisco il proseguimento
        if (Session["cod"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
            return;
        }

        if (
            !ddlModelli.Enabled ||
            string.IsNullOrEmpty(txtTarga.Text) ||
            string.IsNullOrEmpty(txtDataAcquisto.Text) ||
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

        int cod = int.Parse(Session["cod"].ToString());
        int codiceModello = int.Parse(ddlModelli.SelectedValue);
        string targa = txtTarga.Text.Trim().ToUpper();
        string dataAcquisto = txtDataAcquisto.Text;

        Auto a = new Auto(cod, codiceModello, targa, dataAcquisto, costo, prezzo);

        if (a.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Voce già esistente')", true);
            return;
        }

        a.Update();

        ddlMarche.SelectedIndex = 0;
        ddlModelli.Enabled = false;
        txtTarga.Text = "";
        txtDataAcquisto.Text = "";
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
        lbl.Text = "Modifica Effettuata";
    }
}