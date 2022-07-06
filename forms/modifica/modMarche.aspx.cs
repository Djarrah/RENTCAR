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
            
            int cod = int.Parse(Session["cod"].ToString());
            Marche m = new Marche(cod);
            DataTable dt = m.SelectOne();
            
            txt.Text = dt.Rows[0]["descrizione"].ToString();
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

        // Costruisco i parametri per la stringa di query
        string descrizione = txt.Text.Trim();
        int cod = int.Parse(Session["cod"].ToString());

        // Controlli formali
        if (string.IsNullOrEmpty(descrizione))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // Preparazione
        Marche m = new Marche(cod, descrizione);

        // Verifica ridondanza del database
        if (m.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Voce già esistente')", true);
            return;
        }

        // Eseguo la query aprendo e chiudendo la connessione
        m.Update();

        // Aggiorno la tabella e resetto i campi
        txt.Text = "";
        Session["cod"] = null;
        lbl.Text = "Modifica eseguita";
    }
}