using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Spese s = new Spese();

        griglia.DataSource = s.SelectAll();
        griglia.DataBind();
        
        if (!IsPostBack)
        {
            TipiSpese t = new TipiSpese();

            ddlTipoSpesa.DataSource = t.SelectAll();
            ddlTipoSpesa.DataBind();
        }
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        TableCellCollection riga = griglia.SelectedRow.Cells;
        string codiceTipoSpesa = griglia.SelectedDataKey[1].ToString();

        ddlTipoSpesa.SelectedValue = codiceTipoSpesa;
        txtImporto.Text = riga[3].Text;
        txtData.Text = riga[4].Text;
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        // Mi assicuro che una riga sia selezionata
        if (griglia.SelectedRow == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Selezionare una spesa')", true);
            return;
        }

        // Mi assicuro che i campi non siano vuoti
        if (string.IsNullOrEmpty(txtImporto.Text) || string.IsNullOrEmpty(txtData.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Compilare tutti i campi')", true);
            return;
        }

        // Mi assicuro che i dati in ogni campo siano validi
        if (!decimal.TryParse(txtImporto.Text, out decimal res))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Dichiarazione variabili
        int codiceSpesa = (int)griglia.SelectedDataKey[0];
        int codiceTipoSpesa = int.Parse(ddlTipoSpesa.SelectedValue);
        string importo = txtImporto.Text.Trim().Replace(",", ".");
        string dataSpesa = txtData.Text;

        // Configuro i parametri della connessione
        Spese s = new Spese(codiceSpesa, codiceTipoSpesa, importo, dataSpesa);

        // Modifico il record nel DB
        s.Update();

        // Effettuo operazioni di aggiornamento e pulizia
        griglia.DataSource = s.SelectAll();
        griglia.DataBind();
        griglia.SelectedIndex = 0;

        ddlTipoSpesa.SelectedIndex = 0;
        txtImporto.Text = "";
        txtData.Text = "";
    }
}