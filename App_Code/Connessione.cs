using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Gestisce la connessione col DB e i suoi metodi principali
/// </summary>
public class Connessione
{
    // Dichiarazione membri
    public SqlConnection conn = new SqlConnection();

    string connectionString = ConfigurationManager.ConnectionStrings["RENTCARConnectionString"].ConnectionString;

    // Costruttore
    public Connessione()
    {
        conn.ConnectionString = connectionString;
    }

    /// <summary>
    /// Esegue un comando SQL SELECT nel database associato
    /// </summary>
    /// <returns>Una tabella dati risultante dalla query</returns>
    public DataTable EseguiSelect(string query)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        cmd.Connection = conn;
        cmd.CommandText = query;

        adapter.SelectCommand = cmd;
        adapter.Fill(dt);

        return dt;
    }

    /// <summary>
    /// Esegue una Stored Procedure nel DB associato
    /// </summary>
    /// <returns>Una tabella con i dati prelevati dal select</returns>
    public DataTable EseguiSP(string spName)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = spName;

        adapter.SelectCommand = cmd;
        adapter.Fill(dt);

        return dt;
    }

    /// <summary>
    /// Esegue una stored procedure di selezione con parametri
    /// </summary>
    /// <param name="cmd">L'oggetto SqlCommand con i parametri già caricati</param>
    /// <returns>Una tabella contenente i dati selezionati</returns>
    public DataTable EseguiSPSelect(SqlCommand cmd)
    {
        SqlDataAdapter DA = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;

        DA.Fill(dt);
        return dt;
    }

    /// <summary>
    /// Esegue una query SQL senza dati di ritorno
    /// </summary>
    /// <param name="query">La query da eseguire</param>
    public void EseguiCommand(string query)
    {
        SqlCommand cmd = new SqlCommand(query, conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// Esegue una stored procedure con parametri
    /// </summary>
    /// <param name="cmd">L'oggetto SqlCommand con i parametri già caricati</param>
    public void EseguiSPCmd(SqlCommand cmd)
    {
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}