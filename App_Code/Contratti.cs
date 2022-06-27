using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce le interazioni con la tabella dei Contratti
/// </summary>
public class Contratti
{
    int codiceContratto;
    int codiceCliente;
    int codiceAuto;
    string dataInizioContratto;
    string dataTermineContratto;

    #region COSTRUTTORI

    public Contratti() { }

    public Contratti(int codiceCliente, int codiceAuto, string dataInizioContratto, string dataTermineContratto)
    {
        this.codiceCliente = codiceCliente;
        this.codiceAuto = codiceAuto;
        this.dataInizioContratto = dataInizioContratto;
        this.dataTermineContratto = dataTermineContratto;
    }

    public Contratti(int codiceContratto, int codiceCliente, int codiceAuto, string dataInizioContratto, string dataTermineContratto)
    {
        this.codiceContratto = codiceContratto;
        this.codiceCliente = codiceCliente;
        this.codiceAuto = codiceAuto;
        this.dataInizioContratto = dataInizioContratto;
        this.dataTermineContratto = dataTermineContratto;
    }

    #endregion

    #region QUERY DI SELEZIONE

    /// <summary>
    /// Seleziona tutti i contratti nella tabeòòa
    /// </summary>
    /// <returns>Una tabella contenente i dati selezionati</returns>
    public DataTable SelectAll()
    {
        Connessione c = new Connessione();

        return c.EseguiSP("tabContratti_SelectAll");
    }

    /// <summary>
    /// Controlla che esista un record col codice contratto fornito
    /// </summary>
    /// <returns>true se esiste, false se non esiste</returns>
    public bool CheckOne()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabContratti_CheckOne";
        cmd.Parameters.AddWithValue("@codiceContratto", codiceContratto);

        Connessione c = new Connessione();
        DataTable dt = c.EseguiSPSelect(cmd);

        return dt.Rows.Count > 0;
    }

    #endregion

    #region QUERY SENZA RITORNO

    /// <summary>
    /// Inserisce un contratto nella tabella
    /// </summary>
    public void Insert()
    {
        Connessione c = new Connessione();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabContratti_Insert";
        cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente);
        cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto);
        cmd.Parameters.AddWithValue("@dataInizioContratto", dataInizioContratto);
        cmd.Parameters.AddWithValue("@dataTermineContratto", dataTermineContratto);

        c.EseguiSPCmd(cmd);
    }

    /// <summary>
    /// Modifica un contratto nella tabella
    /// </summary>
    public void Update()
    {
        Connessione c = new Connessione();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabContratti_Update";
        cmd.Parameters.AddWithValue("@codiceContratto", codiceContratto);
        cmd.Parameters.AddWithValue("@codiceCliente", codiceCliente);
        cmd.Parameters.AddWithValue("@codiceAuto", codiceAuto);
        cmd.Parameters.AddWithValue("@dataInizioContratto", dataInizioContratto);
        cmd.Parameters.AddWithValue("@dataTermineContratto", dataTermineContratto);

        c.EseguiSPCmd(cmd);
    }

    #endregion
}