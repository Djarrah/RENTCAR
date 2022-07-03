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

        int codiceSpesa = int.Parse(Session["cod"].ToString());
        Spese s = new Spese(codiceSpesa);
        
        if (!s.CheckOne())
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "ATTENZIONE", "alert('Spesa non esistente')", true);
            return;
        }

        s.Delete();

        lbl.Text = "Spesa Eliminata!";
    }
}