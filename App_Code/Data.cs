using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Data
/// </summary>
public class Data
{
    SqlConnection connec;
    public Data()
    {
        //String strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";

        String strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + HttpContext.Current.Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";
        connec = new SqlConnection(strConnec);
    }

    public DataTable getData(string sql)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connec);
            da.Fill(dt);

        }
        catch(SqlException ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
        }
        return dt;
    }

    public void update(string sql)
    {
        try
        {
            SqlCommand com = new SqlCommand(sql, connec);
            connec.Open();
            com.ExecuteNonQuery();
            connec.Close();
        }
        catch (SqlException ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
        }
    }

}