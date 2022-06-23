using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce un login e i relativi metodi
/// </summary>
public class Utenti
{
    public int chiave;
    public string utente;
    public string password;

    #region COSTRUTTORI

    public Utenti() { }

    public Utenti(string utente, string password)
    {
        this.utente = utente;
        this.password = password;
    }

    #endregion

    public DataTable SelectAll()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabUtenti_SelectAll");
    }
    
    public bool Login()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabUtenti_Login");
        cmd.Parameters.AddWithValue("@utente", utente);
        cmd.Parameters.AddWithValue("@password", password);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    public bool Registrato()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabUtenti_CheckOne");
        cmd.Parameters.AddWithValue("@utente", utente);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    public void Insert()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabUtenti_Insert");
        cmd.Parameters.AddWithValue("@utente", utente);
        cmd.Parameters.AddWithValue("@password", password);

        c.EseguiSPCmd(cmd);
    }

    public void Update()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabUtenti_Update");
        cmd.Parameters.AddWithValue("@chiave", chiave);
        cmd.Parameters.AddWithValue("@utente", utente);
        cmd.Parameters.AddWithValue("@password", password);

        c.EseguiSPCmd(cmd);
    }
}