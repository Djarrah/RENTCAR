using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce le interazioni col databse dei Tipi Spese
/// </summary>
public class TipiSpese
{
    public int codiceTipoSpesa;
    public string descrizione;

    #region COSTRUTTORI
    public TipiSpese() { }

    public TipiSpese(string descrizione)
    { 
        this.descrizione = descrizione;
    }

    public TipiSpese(int codiceTipoSpesa, string descrizione)
    {
        this.codiceTipoSpesa = codiceTipoSpesa;
        this.descrizione = descrizione;
    }

    #endregion

    /// <summary>
    /// Seleziona tutti i tipi spese
    /// </summary>
    /// <returns>La tabella contenente i tipi spese</returns>
    public DataTable SelectAll()
    { 
        Connessione c = new Connessione();

        //return c.EseguiSelect("select * from tabTipiSpese order by descrizione");
        return c.EseguiSP("tabTipiSpese_SelectAll");
    }

    /// <summary>
    /// Verifica l'esistenza di un tipo spesa nel DB
    /// </summary>
    /// <returns>Un booleano sull'esistenza del tipo spesa nel DB</returns>
    public bool CheckOne()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabTipiSpese_CheckOne");
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    /// <summary>
    /// Inserisce un tipo spesa nel DB
    /// </summary>
    public void Insert()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabTipiSpese_Insert");
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Aggiorna la descrizione di un tipo spesa
    /// </summary>
    public void Update()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabTipiSpese_Update");
        cmd.Parameters.AddWithValue("@codiceTipoSpesa", codiceTipoSpesa);
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        c.EseguiSPCmd(cmd);
    }
}