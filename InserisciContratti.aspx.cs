using System;
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

    protected void CaricaGriglia()
    {
        Contratti c = new Contratti();

        griglia.DataSource = c.SelectAll();
        griglia.DataBind();
    }
}