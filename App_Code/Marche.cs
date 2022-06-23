using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce le interazioni col database delle Marche
/// </summary>
public class Marche
{
    public int codiceMarca;
    public string descrizione;

    #region COSTRUTTORI
    public Marche() {  }

    public Marche(string descrizione)
    {
        this.descrizione = descrizione;
    }

    public Marche(int codiceMarca, string descrizione)
    {
        this.codiceMarca = codiceMarca;
        this.descrizione = descrizione;
    }

    #endregion

    /// <summary>
    /// Seleziona tutte le marche nel DB
    /// </summary>
    /// <returns>Una tabella dati contenente tutte le marche</returns>
    public DataTable SelectAll()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabMarche_SelectAll");
    }

    /// <summary>
    /// Controlla l'esistenza di una marca nel DB
    /// </summary>
    /// <returns>Un booleano positivo in caso di doppioni</returns>
    public bool CheckOne()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabMarche_CheckOne");
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    /// <summary>
    /// Inserisce una marca nel DB
    /// </summary>
    public void Insert()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabMarche_Insert");
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Aggiorna una determinata marca nel DB
    /// </summary>
    public void Update()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabMarche_Update");
        cmd.Parameters.AddWithValue("codiceMarca", codiceMarca);
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        c.EseguiSPCmd(cmd);
    }
}