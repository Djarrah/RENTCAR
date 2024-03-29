﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CaricaGriglia();

        if (!IsPostBack)
        {
            Clienti cl = new Clienti();
            Auto a = new Auto();

            ddlClienti.DataSource = cl.SelectAll();
            ddlClienti.DataValueField = "codiceCliente";
            ddlClienti.DataTextField = "ragSociale";
            ddlClienti.DataBind();

            ddlAuto.DataSource = a.SelectForDDL();
            ddlAuto.DataValueField = "codiceAuto";
            ddlAuto.DataTextField = "Automobile";
            ddlAuto.DataBind();
        }
    }

    protected void btnInvia_Click(object sender, EventArgs e)
    {
        // Controlli Formali
        if (string.IsNullOrEmpty(txtDataInizio.Text) || string.IsNullOrEmpty(txtDataTermine.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        DateTime inizio = DateTime.Parse(txtDataInizio.Text);
        DateTime termine = DateTime.Parse(txtDataTermine.Text);

        if (inizio > termine)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Data di inizio successiva a quella di fine')", true);
            return;
        }

        // Dichiarazione variabili
        int codiceCliente = int.Parse(ddlClienti.SelectedValue);
        int codiceAuto = int.Parse(ddlAuto.SelectedValue);
        string dataInizio = txtDataInizio.Text;
        string dataTermine = txtDataTermine.Text;

        Contratti c = new Contratti(codiceCliente, codiceAuto, dataInizio, dataTermine);

        // Inserimento
        c.Insert();

        // Pulizia
        ddlAuto.SelectedIndex = 0;
        ddlClienti.SelectedIndex = 0;
        txtDataInizio.Text = "";
        txtDataTermine.Text = "";

        CaricaGriglia();
    }

    protected void CaricaGriglia()
    {
        Contratti c = new Contratti();

        griglia.DataSource = c.SelectAll();
        griglia.DataBind();
    }
}