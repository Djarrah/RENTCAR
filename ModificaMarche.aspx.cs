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
        Marche m = new Marche();

        griglia.DataSource = m.SelectAll();
        griglia.DataBind();
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        // Controllo che ci sia una riga selezionata
        if (griglia.SelectedRow == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Selezionare una riga')", true);
            return;
        }

        // Controlli formali
        if (string.IsNullOrEmpty(txtMarche.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Dichiaro le variabili 
        string nuovaMarca = txtMarche.Text.Trim();
        int codiceMarca = int.Parse(griglia.SelectedRow.Cells[0].Text);

        // Preparo l'oggetto per le operazioni su db
        Marche m = new Marche(codiceMarca, nuovaMarca);

        // Controllo che la nuova marca non esista già nel database
        if (m.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Marca già presente')", true);
            return;
        }

        // Eseguo il command di modifica
        m.Update();

        // Aggiorno tabella Pulisco i campi
        txtMarche.Text = "";

        griglia.DataSource = m.SelectAll();
        griglia.DataBind();
        griglia.SelectedIndex = 0;

        // Confermo la modifica dati
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SUCCESSO", "alert('Dati modificati correttamente')", true);
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Inserisco la descrizione della marca selezionata nel textbox
        txtMarche.Text = griglia.SelectedRow.Cells[1].Text;
    }
}