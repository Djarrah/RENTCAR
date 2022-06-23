using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    // Creo le variabili di connessione
    Connessione c = new Connessione();
    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Spese s = new Spese();

        griglia.DataSource = s.SelectAll();
        griglia.DataBind();
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodiceSpesa.Text = griglia.SelectedRow.Cells[0].Text;
    }

    protected void btnElimina_Click(object sender, EventArgs e)
    {
        // Dichiarazione variabili
        string codiceSpesaTesto = txtCodiceSpesa.Text.Trim();

        // Controllo che il campo non sia vuoto
        if (string.IsNullOrEmpty(codiceSpesaTesto))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }
        
        // Controllo che sia stato immesso un ID numerico
        if (!int.TryParse(codiceSpesaTesto, out int codiceSpesa))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Immettere un ID numerico o selezionare una riga')", true);
            return;
        }

        // Configuro i parametri di connessione
        Spese s = new Spese(codiceSpesa);

        // Eseguo il controllo
        if (!s.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Immettere un ID valido')", true);
            return;
        }

        // Elimino il record dal database
        s.Delete();

        // Pulisco i campi, aggiorno la tabella e invio messaggio di conferma
        griglia.DataSource = s.SelectAll();
        griglia.DataBind();
        griglia.SelectedIndex = 0;

        txtCodiceSpesa.Text = "";

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Spesa Eliminata')", true);
    }
}