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

            Clienti c = new Clienti();
            ddlClienti.DataSource = c.SelectAll();
            ddlClienti.DataValueField = "codiceCliente";
            ddlClienti.DataTextField = "ragSociale";
            ddlClienti.DataBind();

            Auto a = new Auto();
            ddlAuto.DataSource = a.SelectForDDL();
            ddlAuto.DataValueField = "codiceAuto";
            ddlAuto.DataTextField = "Automobile";
            ddlAuto.DataBind();

            int cod = int.Parse(Session["cod"].ToString());
            Contratti co = new Contratti(cod);
            DataTable dt = co.SelectOne();

            ddlClienti.SelectedValue = dt.Rows[0]["codiceCliente"].ToString();
            ddlAuto.SelectedValue = dt.Rows[0]["codiceAuto"].ToString();
            txtDataInizio.Text = dt.Rows[0].Field<DateTime>(3).ToString("yyyy-MM-dd");
            txtDataTermine.Text = dt.Rows[0].Field<DateTime>(4).ToString("yyyy-MM-dd");
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
        if (string.IsNullOrEmpty(txtDataInizio.Text) || string.IsNullOrEmpty(txtDataTermine.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // Preparazione
        int codiceContratto = int.Parse(Session["cod"].ToString());
        int codiceCliente = int.Parse(ddlClienti.SelectedValue);
        int codiceAuto = int.Parse(ddlAuto.SelectedValue);
        string dataInizioContratto = txtDataInizio.Text;
        string dataTermineContratto = txtDataTermine.Text;

        Contratti c = new Contratti(codiceContratto, codiceCliente, codiceAuto, dataInizioContratto, dataTermineContratto);

        // Verifica esistenza nel database
        if (!c.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Contratto non esistente')", true);
            return;
        }

        // Eseguo la query aprendo e chiudendo la connessione
        c.Update();

        // Aggiorno la tabella e resetto i campi
        ddlClienti.SelectedIndex = 0;
        ddlAuto.SelectedIndex = 0;
        txtDataInizio.Text = "";
        txtDataTermine.Text = "";
        Session["cod"] = null;
        lbl.Text = "Modifica eseguita";
    }
}