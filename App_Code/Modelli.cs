using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce le interazioni con la tabella tabModelli
/// </summary>
public class Modelli
{
    public int codiceModello;
    public int codiceMarca;
    public string descrizione;

    #region COSTRUTTORI

    public Modelli() { }

    public Modelli(int codiceMarca, string descrizione)
    {
        this.codiceMarca = codiceMarca;
        this.descrizione = descrizione;
    }

    public Modelli(int codiceModello, int codiceMarca, string descrizione)
    {
        this.codiceModello = codiceModello;
        this.codiceMarca = codiceMarca;
        this.descrizione= descrizione;
    }

    #endregion

    /// <summary>
    /// Seleziona i dati dalla tabella dei modelli incrociandoli con quella delle marche
    /// </summary>
    /// <returns>Una tabella con i dati selezionati</returns>
    public DataTable SelectAll()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabModelli_SelectAll");
    }

    /// <summary>
    /// Controlla l'esistenza di un record con la coppia codiceMarca e descrizione fornite
    /// </summary>
    /// <returns>true se esiste, false se non esiste</returns>
    public bool CheckOne()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabModelli_CheckOne");
        cmd.Parameters.AddWithValue("@codiceMarca", codiceMarca);
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    /// <summary>
    /// Inserisce un nuovo record
    /// </summary>
    public void Insert()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabModelli_Insert");
        cmd.Parameters.AddWithValue("@codiceMarca", codiceMarca);
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Aggiorna il record col codiceModello fornito
    /// </summary>
    public void Update()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabModelli_Update");
        cmd.Parameters.AddWithValue("@codiceModello", codiceModello);
        cmd.Parameters.AddWithValue("@codiceMarca", codiceMarca);
        cmd.Parameters.AddWithValue("@descrizione", descrizione);

        c.EseguiSPCmd(cmd);
    }
}