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

    public Contratti(int codiceContratto)
    {
        this.codiceContratto = codiceContratto;
    }

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
    /// Seleziona il record con il codiceContratto specificato
    /// </summary>
    /// <returns>Una tabella contenente i dati del record</returns>
    public DataTable SelectOne()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabContratti_SelectOne";
        cmd.Parameters.AddWithValue("@codiceContratto", codiceContratto);

        Connessione c = new Connessione();
        return c.EseguiSPSelect(cmd);
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

    /// <summary>
    /// Elimina il record col codiceContratto fornito
    /// </summary>
    public void Delete()
    {
        Connessione c = new Connessione();
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "tabContratti_Delete";
        cmd.Parameters.AddWithValue("@codiceContratto", codiceContratto);

        c.EseguiSPCmd(cmd);
    }

    #endregion

    /// <summary>
    /// Gestisce le operazioni di contabilità
    /// </summary>
    public class Contabilita
    {
        int anno;

        public Contabilita(int anno) { this.anno = anno; }

        /// <summary>
        /// Determina il totale delle spese per un determinato anno
        /// </summary>
        /// <returns>Il totale delle spese come decimale</returns>
        public decimal SpesePerAnno()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tabSpese_SumForYear";
            cmd.Parameters.AddWithValue("@anno", anno);

            Connessione conn = new Connessione();
            DataTable dt = conn.EseguiSPSelect(cmd);

            return decimal.Parse(dt.Rows[0]["Spese"].ToString());
        }

        /// <summary>
        /// Determina il totale del fatturato per un determinato anno
        /// </summary>
        /// <returns>Il totale del fatturato come decimale</returns>
        public decimal FatturatoPerAnno()
        {
            decimal fatturatoAnnuo = 0;
            for (int i = 1; i < 13; i++) { fatturatoAnnuo += FatturatoPerMese(i); }

            return fatturatoAnnuo;
        }

        /// <summary>
        /// Determina il otale dei ricavi per un determinato anno
        /// </summary>
        /// <returns>I ricavi come decimale</returns>
        public decimal RicaviPerAnno() { return FatturatoPerAnno() - SpesePerAnno(); }

        /// <summary>
        /// Determina il totale del fatturato per un determinato mese di un determinato anno
        /// </summary>
        /// <param name="mese">Il numero del mese da considerare</param>
        /// <returns>Il totale del fatturato come decimale</returns>
        public decimal FatturatoPerMese(int mese)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tabContratti_MonthlySumByYear";
            cmd.Parameters.AddWithValue("@anno", anno);
            cmd.Parameters.AddWithValue("@mese", mese);

            Connessione conn = new Connessione();
            DataTable dt = conn.EseguiSPSelect(cmd);

            return decimal.Parse(dt.Rows[0]["Fatturato"].ToString());
        }

        public DataTable TabellaFatturato()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tabContratti_SelectMonthlySum";
            cmd.Parameters.AddWithValue("@anno", anno);

            Connessione conn = new Connessione();
            return conn.EseguiSPSelect(cmd);
        }
    }
}