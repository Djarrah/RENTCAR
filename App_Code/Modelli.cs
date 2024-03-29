﻿using System;
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

    public Modelli(int codiceModello)
    {
        this.codiceModello = codiceModello;
    }

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
    /// Seleziona un record col codice specificato
    /// </summary>
    /// <returns>Una tabella dati contenente il record selezionato</returns>
    public DataTable SelectOne()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabModelli_SelectOne";
        cmd.Parameters.AddWithValue("codiceModello", codiceModello);

        Connessione c = new Connessione();
        return c.EseguiSPSelect(cmd);
    }

    /// <summary>
    /// Seleziona la coppia Marca-Modello per l'inserimento in una ddl
    /// </summary>
    /// <returns>Una tabella dato formattata [Marca] [Modello]</returns>
    public DataTable SelectForDDL()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabModelli_SelectForDDL");
    }

    /// <summary>
    /// Seleziona i modelli di una determinata marca
    /// </summary>
    /// <param name="codiceMarca">Il codice della marca da selezionare come filtro</param>
    /// <returns>Una tabella dati contenente i modelli selezionati</returns>
    public DataTable SelectMarca(int codiceMarca)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabModelli_SelectMarca";
        cmd.Parameters.AddWithValue("codiceMarca", codiceMarca);

        Connessione c = new Connessione();
        return c.EseguiSPSelect(cmd);
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