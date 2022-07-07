using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 2; i--)
            {
                ddlAnno.Items.Add(i.ToString());
            }
        }
    }

    protected void btnCalcola_Click(object sender, EventArgs e)
    {
        int anno = int.Parse(ddlAnno.SelectedValue);
        Contratti.Contabilita c = new Contratti.Contabilita(anno);
        DateTimeFormatInfo dtf = CultureInfo.CurrentCulture.DateTimeFormat;

        lblSpese.Text = "€ " + c.SpesePerAnno();
        lblFatturato.Text = "€ " + c.FatturatoPerAnno();
        lblRicavi.Text = "€ " + c.RicaviPerAnno();

        try
        {
            griglia.DataSource = c.TabellaFatturato();
            griglia.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERRORE", $"alert('{ex.Message}')", true);
        }


        //string tabellaMesi = "";
        //for (int i = 1; i < 13; i++)
        //{
        //    string nomeMese = dtf.GetMonthName(i);
        //    nomeMese = char.ToUpper(nomeMese[0]) + nomeMese.Substring(1);

        //    decimal fatturatoMese = c.FatturatoPerMese(i);

        //    tabellaMesi += $"<tr><td>{nomeMese}</td><td>{fatturatoMese}</td></tr>";
        //}

        //litTabellaMesi.Text = tabellaMesi;
    }
}