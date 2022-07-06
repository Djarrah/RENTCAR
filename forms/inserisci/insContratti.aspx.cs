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
        }
    }

    protected void btnInserisci_Click(object sender, EventArgs e)
    {
        // Controlli formali sui campi obbligatori
        if (string.IsNullOrEmpty(txtDataInizio.Text) || string.IsNullOrEmpty(txtDataTermine.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }

        // Creazione parametri
        int codiceCliente = int.Parse(ddlClienti.SelectedValue);
        int codiceAuto = int.Parse(ddlAuto.SelectedValue);
        string dataInizio = txtDataInizio.Text;
        string dataTermine = txtDataTermine.Text;

        // Creare l' oggetto per l'interazione col database
        Contratti c = new Contratti(codiceCliente, codiceAuto, dataInizio, dataTermine);

        // Procedo con l'Inserimento
        c.Insert();

        // Pulizia campi e aggiornamento tabella
        lbl.Text = "Inserimento effettuato";
        ddlClienti.SelectedIndex = 0;
        ddlAuto.SelectedIndex = 0;
        txtDataInizio.Text = "";
        txtDataTermine.Text = "";
    }
}