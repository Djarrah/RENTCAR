using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forms_elimina_eliSpese : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["cod"] == null)
            {
                lbl.Text = "ERRORE, selezionare una voce";
                tabella.Visible = false;

                return;
            }
        }
    }

    protected void btnElimina_Click(object sender, EventArgs e)
    {
        // Se non vi è nessun elemento selezionato impedisco il proseguimento
        if (Session["cod"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Seleziona una riga per poterla eliminare')", true);
            return;
        }

        int codiceContratto = int.Parse(Session["cod"].ToString());
        Contratti c = new Contratti(codiceContratto);
        
        if (!c.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Contratto non esistente')", true);
            return;
        }

        c.Delete();

        lbl.Text = "Contratto Eliminato!";
    }
}