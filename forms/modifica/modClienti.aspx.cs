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
            Clienti c = new Clienti(cod);
            DataRow sel = c.SelectOne().Rows[0];

            txtRagSoc.Text = sel["ragSociale"].ToString();
            txtPIVA.Text = sel["pIVA"].ToString().Replace("&nbsp;", "");
            txtCF.Text = sel["CF"].ToString().Replace("&nbsp;", "");
            txtIndirizzo.Text = sel["indirizzo"].ToString();
            txtCitta.Text = sel["citta"].ToString();
            txtProvincia.Text = sel["provincia"].ToString();
            txtCAP.Text = sel["cap"].ToString();
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

        // Dichiarazioni variabili
        int codiceCliente = int.Parse(Session["cod"].ToString());
        string ragSociale = txtRagSoc.Text.Trim();
        string PIVA = txtPIVA.Text.Trim();
        string CF = txtCF.Text.Trim();
        string indirizzo = txtIndirizzo.Text.Trim();
        string citta = txtCitta.Text.Trim();
        string provincia = txtProvincia.Text.Trim().ToUpper();
        string cap = txtCAP.Text.Trim();

        // Controlli formali sui campi obbligatori
        if (
            string.IsNullOrEmpty(ragSociale) ||
            string.IsNullOrEmpty(indirizzo) ||
            string.IsNullOrEmpty(citta) ||
            string.IsNullOrEmpty(provincia) ||
            string.IsNullOrEmpty(cap)
            )
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // L' utente deve inserire almeno uno dei due campi tra PIVA e CF
        if (string.IsNullOrEmpty(PIVA) && string.IsNullOrEmpty(CF))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // Configurazione elementi connessione
        Clienti c = new Clienti(codiceCliente, ragSociale, PIVA, CF, indirizzo, citta, provincia, cap);

        // Controllo ridondanza
        if (c.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati ridondanti')", true);
            return;
        }

        // Modifica record
        c.Update();

        // Operazioni di cleanup

        txtRagSoc.Text = "";
        txtPIVA.Text = "";
        txtCF.Text = "";
        txtIndirizzo.Text = "";
        txtCitta.Text = "";
        txtProvincia.Text = "";
        txtCAP.Text = "";
        lbl.Text = "Modifica Effettuata";
    }
}