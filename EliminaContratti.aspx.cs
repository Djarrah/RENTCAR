using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CaricaGriglia();
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtID.Text = griglia.SelectedRow.Cells[0].Text;
    }

    protected void btnElimina_Click(object sender, EventArgs e)
    {
        // Dichiarazione variabili
        string id = txtID.Text.Trim();

        // Controllo che il campo non sia vuoto
        if (string.IsNullOrEmpty(id))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Controllo che sia stato immesso un ID numerico
        if (!int.TryParse(id, out int codiceContratto))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Immettere un ID numerico o selezionare una riga')", true);
            return;
        }

        // Configuro i parametri di connessione
        Contratti c = new Contratti(codiceContratto);

        // Eseguo il controllo
        if (!c.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Immettere un ID valido')", true);
            return;
        }

        // Elimino il record dal database
        c.Delete();

        // Pulisco i campi
        CaricaGriglia();

        griglia.SelectedIndex = 0;
        txtID.Text = "";
    }

    protected void CaricaGriglia()
    {
        Contratti c = new Contratti();

        griglia.DataSource = c.SelectAll();
        griglia.DataBind();
    }
}