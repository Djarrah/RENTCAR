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
        Contabilita c = new Contabilita(anno);
        DateTimeFormatInfo dtf = CultureInfo.CurrentCulture.DateTimeFormat;

        lblSpese.Text = "€ " + c.SpesePerAnno();
        lblFatturato.Text = "€ " + c.FatturatoPerAnno();
        lblRicavi.Text= "€ " + c.RicaviPerAnno();

        string tabellaMesi = "";
        for (int i = 1; i < 13; i++)
        {
            string nomeMese = dtf.GetMonthName(i);
            nomeMese = char.ToUpper(nomeMese[0]) + nomeMese.Substring(1);

            decimal fatturatoMese = c.FatturatoPerMese(i);

            tabellaMesi += $"<tr><td>{nomeMese}</td><td>{fatturatoMese}</td></tr>";
        }

        litTabellaMesi.Text = tabellaMesi;
    }
}