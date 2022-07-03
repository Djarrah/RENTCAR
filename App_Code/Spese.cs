using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce le interazioni con la tabella tabSpese del DB
/// </summary>
public class Spese
{
    int codiceSpesa;
    int codiceTipoSpesa;
    decimal importo;
    string dataSpesa;

    #region COSTRUTTORI

    public Spese() { }

    public Spese(int codiceSpesa) { this.codiceSpesa = codiceSpesa; }

    public Spese(int codiceTipoSpesa, decimal importo, string dataSpesa)
    {
        this.codiceTipoSpesa = codiceTipoSpesa;
        this.importo = importo;
        this.dataSpesa = dataSpesa;
    }

    public Spese(int codiceSpesa, int codiceTipoSpesa, decimal importo, string dataSpesa)
    {
        this.codiceSpesa = codiceSpesa;
        this.codiceTipoSpesa = codiceTipoSpesa;
        this.importo = importo;
        this.dataSpesa = dataSpesa;
    }

    #endregion

    /// <summary>
    /// Seleziona i record delle spese incrociandoli con i tipi di spesa
    /// </summary>
    /// <returns>Una tabella contenente i dati selezionati</returns>
    public DataTable SelectAll()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabSpese_SelectAll");
    }

    /// <summary>
    /// Seleziona il record con il codiceSpesa specificato
    /// </summary>
    /// <returns>Una tabella contenente i dati del record</returns>
    public DataTable SelectOne()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabSpese_SelectOne";
        cmd.Parameters.AddWithValue("@codiceSpesa", codiceSpesa);

        Connessione c = new Connessione();
        return c.EseguiSPSelect(cmd);
    }

    /// <summary>
    /// Controlla se esiste un record col codiceSpesa fornito
    /// </summary>
    /// <returns>true se esiste, false se non esiste</returns>
    public bool CheckOne()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabSpese_CheckOne");
        cmd.Parameters.AddWithValue("@codiceSpesa", codiceSpesa);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    /// <summary>
    /// Inserisce un record spesa nel DB
    /// </summary>
    public void Insert()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabSpese_Insert");
        cmd.Parameters.AddWithValue("@codiceTipoSpesa", codiceTipoSpesa);
        cmd.Parameters.AddWithValue("@importo", importo);
        cmd.Parameters.AddWithValue("@dataSpesa", dataSpesa);

        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Aggiorna un record col codiceSpesa fornito
    /// </summary>
    public void Update()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabSpese_Update");
        cmd.Parameters.AddWithValue("@codiceSpesa", codiceSpesa);
        cmd.Parameters.AddWithValue("@codiceTipoSpesa", codiceTipoSpesa);
        cmd.Parameters.AddWithValue("@importo", importo);
        cmd.Parameters.AddWithValue("@dataSpesa", dataSpesa);

        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Elimina il record col codiceSpesa fornito nel DB
    /// </summary>
    public void Delete()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabSpese_Delete");
        cmd.Parameters.AddWithValue("@codiceSpesa", codiceSpesa);

        c.EseguiSPCmd(cmd);
    }
}