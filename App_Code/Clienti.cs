using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce le operazioni con la tabella "tabClienti" del Database
/// </summary>
public class Clienti
{
    public int codiceCliente;
    public string ragSoc;
    public string pIVA;
    public string CF;
    public string indirizzo;
    public string citta;
    public string provincia;
    public string cap;

    #region COSTRUTTORI

    public Clienti() { }

    public Clienti(int codiceCliente)
    {
        this.codiceCliente = codiceCliente;
    }

    public Clienti(string ragSoc, string pIVA, string CF, string indirizzo, string citta, string provincia, string cap)
    {
        this.ragSoc = ragSoc;
        this.pIVA = pIVA;
        this.CF = CF;
        this.indirizzo = indirizzo;
        this.citta = citta;
        this.provincia = provincia;
        this.cap = cap;
    }

    public Clienti(int codiceCliente, string ragSoc, string pIVA, string CF, string indirizzo, string citta, string provincia, string cap)
    {
        this.codiceCliente = codiceCliente;
        this.ragSoc = ragSoc;
        this.pIVA = pIVA;
        this.CF = CF;
        this.indirizzo = indirizzo;
        this.citta = citta;
        this.provincia = provincia;
        this.cap = cap;
    }

    #endregion

    /// <summary>
    /// Seleziona tutti i record dalla tabella
    /// </summary>
    /// <returns>Una tabella dati contenente i record selezionati</returns>
    public DataTable SelectAll()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabClienti_SelectAll");
    }

    /// <summary>
    /// Seleziona un record col codice specificato
    /// </summary>
    /// <returns>Una tabella dati contenente il record selezionato</returns>
    public DataTable SelectOne()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabClienti_SelectOne";
        cmd.Parameters.AddWithValue("codiceCliente", codiceCliente);

        Connessione c = new Connessione();
        return c.EseguiSPSelect(cmd);
    }

    /// <summary>
    /// Controlla che esista almeno un record con la coppia PIVA-CF memorizzata
    /// </summary>
    /// <returns>true se esiste, falso se non esiste</returns>
    public bool CheckOne()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabClienti_CheckOne");
        cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente);
        cmd.Parameters.AddWithValue("@pIVA", pIVA);
        cmd.Parameters.AddWithValue("@CF", CF);

        DataTable dt = c.EseguiSPSelect(cmd);
        return dt.Rows.Count > 0;
    }

    /// <summary>
    /// Inserisce un record nel db
    /// </summary>
    public void Insert()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabClienti_Insert");
        cmd.Parameters.AddWithValue("@ragSoc", ragSoc);
        cmd.Parameters.AddWithValue("@pIVA", pIVA);
        cmd.Parameters.AddWithValue("@CF", CF);
        cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
        cmd.Parameters.AddWithValue("@citta", citta);
        cmd.Parameters.AddWithValue("@provincia", provincia);
        cmd.Parameters.AddWithValue("@cap", cap);

        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Aggiorna un record nel DB chiamandolo per codiceCliente
    /// </summary>
    public void Update()
    {
        Connessione c = new Connessione();

        SqlCommand cmd = new SqlCommand("tabClienti_Update");
        cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente);
        cmd.Parameters.AddWithValue("@ragSoc", ragSoc);
        cmd.Parameters.AddWithValue("@pIVA", pIVA);
        cmd.Parameters.AddWithValue("@CF", CF);
        cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
        cmd.Parameters.AddWithValue("@citta", citta);
        cmd.Parameters.AddWithValue("@provincia", provincia);
        cmd.Parameters.AddWithValue("@cap", cap);

        c.EseguiSPCmd(cmd);
    }
}