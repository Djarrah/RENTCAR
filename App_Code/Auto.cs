using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce le interazioni con la tabella "Auto" del DB
/// </summary>
public class Auto
{
    int codiceAuto;
    int codiceModello;
    string targa;
    string dataAcquisto;
    string costo;
    string prezzo;

    #region COSTRUTTORI

    public Auto() { }

    public Auto(int codiceModello, string targa, string dataAcquisto, string costo, string prezzo)
    {
        this.codiceModello = codiceModello;
        this.targa = targa;
        this.dataAcquisto = dataAcquisto;
        this.costo = costo;
        this.prezzo = prezzo;
    }

    public Auto(int codiceAuto, int codiceModello, string targa, string dataAcquisto, string costo, string prezzo)
    {
        this.codiceAuto = codiceAuto;
        this.codiceModello = codiceModello;
        this.targa = targa;
        this.dataAcquisto = dataAcquisto;
        this.costo = costo;
        this.prezzo = prezzo;
    }

    #endregion

    #region QUERY DI SELEZIONE

    /// <summary>
    /// Seleziona tutti i record nella tabella
    /// </summary>
    /// <returns>Una tabella contenente i dati selezionati</returns>
    public DataTable SelectAll()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabAuto_SelectAll");
    }

    /// <summary>
    /// Seleziona le auto in un formato leggibile da una DDL
    /// </summary>
    /// <returns>Una tabella dati contenente le auto in formato Marca Modello (Targa)</returns>
    public DataTable SelectForDDL()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabAuto_SelectForDDL");
    }

    /// <summary>
    /// Controlla se esiste un auto con la stessa targa diversa da quella che si sta modificando/immettendo
    /// </summary>
    /// <returns>true se esiste, falso se non esiste</returns>
    public bool CheckOne()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabAuto_CheckOne";
        cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto);
        cmd.Parameters.AddWithValue("@targa", targa);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    #endregion

    #region QUERY SENZA RITORNO

    /// <summary>
    /// Inserisce un auto nella tabella
    /// </summary>
    public void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabAuto_Insert";
        cmd.Parameters.AddWithValue("@codiceModello", codiceModello);
        cmd.Parameters.AddWithValue("@targa", targa);
        cmd.Parameters.AddWithValue("@dataAcquisto", dataAcquisto);
        cmd.Parameters.AddWithValue("@costo", costo);
        cmd.Parameters.AddWithValue("@prezzo", prezzo);

        Connessione c = new Connessione();
        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Aggiorna un auto nella tabella
    /// </summary>
    public void Update()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabAuto_Update";
        cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto);
        cmd.Parameters.AddWithValue("@codiceModello", codiceModello);
        cmd.Parameters.AddWithValue("@targa", targa);
        cmd.Parameters.AddWithValue("@dataAcquisto", dataAcquisto);
        cmd.Parameters.AddWithValue("@costo", costo);
        cmd.Parameters.AddWithValue("@prezzo", prezzo);

        Connessione c = new Connessione();
        c.EseguiSPCmd(cmd);
    }

    #endregion
}