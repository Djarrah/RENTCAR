using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Contabilita
/// </summary>
public class Contabilita
{
    int anno;

    public Contabilita(int anno) { this.anno = anno; }

    public decimal SpesePerAnno()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "tabSpese_SumForYear";
        cmd.Parameters.AddWithValue("@anno", anno);

        Connessione conn = new Connessione();
        DataTable dt = conn.EseguiSPSelect(cmd);

        return decimal.Parse(dt.Rows[0]["Spese"].ToString());
    }

    public decimal FatturatoPerAnno()
    {
        decimal fatturatoAnnuo = 0;
        for(int i=1; i<13; i++) { fatturatoAnnuo += FatturatoPerMese(i); }

        return fatturatoAnnuo;
    }

    public decimal RicaviPerAnno() { return FatturatoPerAnno() - SpesePerAnno(); }

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
}