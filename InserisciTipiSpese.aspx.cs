﻿using System;
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
        CaricaGriglia();
    }

    protected void CaricaGriglia()
    {
        TipiSpese t = new TipiSpese();

        griglia.DataSource = t.SelectAll();
        griglia.DataBind();
    }

    protected void btnCaricaGriglia_Click(object sender, EventArgs e)
    {
        CaricaGriglia();
    }
}