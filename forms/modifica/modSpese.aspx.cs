using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modifica : System.Web.UI.Page
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

            TipiSpese ts = new TipiSpese();
            ddlTipiSpese.DataSource = ts.SelectAll();
            ddlTipiSpese.DataValueField = "codiceTipoSpesa";
            ddlTipiSpese.DataTextField = "descrizione";
            ddlTipiSpese.DataBind();

            int cod = int.Parse(Session["cod"].ToString());
            Spese s = new Spese(cod);
            DataTable dt = s.SelectOne();

            ddlTipiSpese.SelectedValue = dt.Rows[0]["codiceTipoSpesa"].ToString();
            txtImporto.Text = dt.Rows[0]["importo"].ToString();
            txtDataSpesa.Text = dt.Rows[0].Field<DateTime>(3).ToString("yyyy-MM-dd");
        }
    }

    protected void btnCambia_Click(object sender, EventArgs e)
    {
        // Se non vi è nessun elemento selezionato impedisco il proseguimento
        if (Session["cod"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
            return;
        }

        // Controlli formali
        if (string.IsNullOrEmpty(txtDataSpesa.Text) || string.IsNullOrEmpty(txtImporto.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        if (!decimal.TryParse(txtImporto.Text.Replace('.' , ','), out decimal importo))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        int codiceSpesa = int.Parse(Session["cod"].ToString());
        int codiceTipoSpesa = int.Parse(ddlTipiSpese.SelectedValue);
        string dataSpesa = txtDataSpesa.Text;

        // Preparazione
        Spese s = new Spese(codiceSpesa, codiceTipoSpesa, importo, dataSpesa);

        // Verifica ridondanza del database
        if (!s.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Record non esistente')", true);
            return;
        }

        // Eseguo la query aprendo e chiudendo la connessione
        s.Update();

        // Aggiorno la tabella e resetto i campi
        ddlTipiSpese.SelectedIndex = 0;
        txtDataSpesa.Text = "";
        txtImporto.Text = "";
        Session["codTipoSpesa"] = null;
        lbl.Text = "Modifica eseguita";
    }
}