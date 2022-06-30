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
            if (Session["codTipoSpesa"] == null)
            {
                lbl.Text = "ERRORE, selezionare una voce";
                tabella.Visible = false;

                return;
            }
            
            int codTipoSpesa = int.Parse(Session["codTipoSpesa"].ToString());
            TipiSpese t = new TipiSpese(codTipoSpesa);
            DataTable dt = t.SelectOne();
            
            txtTipoSpesa.Text = dt.Rows[0]["descrizione"].ToString();
        }
    }

    protected void btnCambia_Click(object sender, EventArgs e)
    {
        // Se non vi è nessun elemento selezionato impedisco il proseguimento
        if (Session["codTipoSpesa"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
            return;
        }

        // Costruisco i parametri per la stringa di query
        string descrizione = txtTipoSpesa.Text.Trim();
        int codTipoSpesa = int.Parse(Session["codTipoSpesa"].ToString());

        // Controlli formali
        if (string.IsNullOrEmpty(descrizione))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // Preparazione
        TipiSpese t = new TipiSpese(codTipoSpesa, descrizione);

        // Verifica ridondanza del database
        if (t.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Tipo Spesa già esistente')", true);
            return;
        }

        // Eseguo la query aprendo e chiudendo la connessione
        t.Update();

        // Aggiorno la tabella e resetto i campi
        txtTipoSpesa.Text = "";
        Session["codTipoSpesa"] = null;
        lbl.Text = "Modifica eseguita";
    }
}