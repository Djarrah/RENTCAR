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
    }

    protected void griglia_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["cod"] = griglia.SelectedDataKey[0];
        btnModifica.Enabled = true;
    }

    protected void btnCaricaGriglia_Click(object sender, EventArgs e)
    {
        CaricaGriglia();
    }

    protected void CaricaGriglia()
    {
        Modelli m = new Modelli();

        griglia.DataSource = m.SelectAll();
        griglia.DataBind();
    }
}