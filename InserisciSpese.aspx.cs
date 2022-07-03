using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region INUTILE
        //// Evito che la DDL si popoli ad ogni caricamento della pagina
        //if (!IsPostBack)
        //{
        //    // Creo gli elementi della connessione
        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    DataTable dt = new DataTable();

        //    // Configuro gli elementi della connessione
        //    conn.ConnectionString = @"Data Source=CRIMSON-GATE\SQLEXPRESS;Initial Catalog=RENTCAR;Integrated Security=true";

        //    cmd.Connection = conn;
        //    cmd.CommandText = "select * from tabTipiSpese";

        //    adapter.SelectCommand = cmd;
        //    adapter.Fill(dt);

        //    // Popolo la DDL
        //    ddlTipoSpesa.DataSource = dt;
        //    ddlTipoSpesa.DataValueField = "codiceTipoSpesa";
        //    ddlTipoSpesa.DataTextField = "descrizione";
        //}

        //// Lego la ddl e l'origine in modo da mostrare le voci (lo faccio ad ogni caricamento della pagina)
        //ddlTipoSpesa.DataBind();
        #endregion

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

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        // Faccio i controlli formali prima di riservare memoria alle variabili
        if (string.IsNullOrEmpty(txtImporto.Text) || string.IsNullOrEmpty(txtDataSpesa.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        if (decimal.TryParse(txtImporto.Text.Replace('.', ','), out decimal importo) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Dichiaro le variabili da inserire nel record
        int codiceTipoSpesa = int.Parse(ddlTipoSpesa.SelectedValue);
        string dataSpesa = txtDataSpesa.Text;

        // Creo gli elementi della connessione
        Spese s = new Spese(codiceTipoSpesa, importo, dataSpesa);

        // Inserire i dati
        s.Insert();

        // Mostro il messaggio di conferma
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SUCCESSO", "alert('Spesa immessa correttamente)", true);

        // Pulisco i campi
        ddlTipoSpesa.SelectedIndex = 0;
        txtImporto.Text = "";
        txtDataSpesa.Text = "";

        // Lego la griglia con l'origine dati
        griglia.DataSource = s.SelectAll();
        griglia.DataBind();
    }
}