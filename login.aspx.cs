using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        // Dichiaro variabili        
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Controlli formali
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Configuro i parametri della connessione
        Utenti u = new Utenti(username, password);

        // Controllo che l' utente sia registrato
        if (!u.Registrato())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Controllo che la password corrisponda
        if (u.Login())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Dati non validi')", true);
            return;
        }

        // Se la convalida ha avuto successo, reindirizzo alla pagina default
        Response.Redirect("Default.aspx");
    }

    // Non usata, da mettere nella pagina di registrazione
    //protected void btnRegistrati_Click(object sender, EventArgs e)
    //{
    //    // Dichiaro variabili        
    //    string username = txtUsername.Text.Trim();
    //    string password = txtPassword.Text.Trim();

    //    // Controlli formali
    //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Uno o più campi vuoti')", true);
    //        return;
    //    }

    //    // Controllo che l' utente non sia registrato
    //    // Configuro i parametri della connessione
    //    cmd.Connection = conn;
    //    cmd.CommandText = "select count(*) as quanti from tabUTENTI where utente='" + username + "'";

    //    DA.SelectCommand = cmd;
    //    DA.Fill(dtUtenti);

    //    int quanti = (int)dtUtenti.Rows[0]["quanti"];

    //    // Faccio la verifica
    //    if (quanti > 0)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ATTENZIONE", "alert('Utente già registrato')", true);
    //        return;
    //    }

    //    // Inserisco nel database il nuovo utente
    //    cmd.CommandText = "insert into tabUTENTI values('" + username + "','" + password + "')";

    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();

    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CONGRATULAZIONI", "alert('Nuovo utente registrato')", true);
    //}
}