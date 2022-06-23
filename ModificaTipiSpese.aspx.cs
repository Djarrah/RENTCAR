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
    protected void Page_Load(object sender, EventArgs e)
    {
        TipiSpese t = new TipiSpese();

        griglia.DataSource = t.SelectAll();
        griglia.DataBind();
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTipoSpesa.Text = griglia.SelectedRow.Cells[1].Text;
    }

    protected void btnCambia_Click(object sender, EventArgs e)
    {
        // Se non vi è nessun elemento selezionato impedisco il proseguimento
        if (griglia.SelectedRow == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla modificare')", true);
            return;
        }

        // Costruisco i parametri per la stringa di query
        string descrizione = txtTipoSpesa.Text.Trim();
        int chiaveRecord = int.Parse(griglia.SelectedRow.Cells[0].Text.ToString());
        
        // Controlli formali
        if (string.IsNullOrEmpty(descrizione))
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ERRORE", "alert('Dati non validi')", true);
            return;
        }
        
        // Preparazione
        TipiSpese t = new TipiSpese(chiaveRecord, descrizione);

        // Verifica ridondanza del database
        if (t.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Tipo Spesa già esistente')", true);
            return;
        }

        // Eseguo la query aprendo e chiudendo la connessione
        t.Update();

        // Aggiorno la tabella e resetto i campi
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SUCCESSO", "alert('Dati modificati correttamente')", true);
        txtTipoSpesa.Text = "";

        griglia.DataSource = t.SelectAll();
        griglia.DataBind();
        griglia.SelectedIndex = 0;
    }
}