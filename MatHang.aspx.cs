using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class MatHang : System.Web.UI.Page
{
    string strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\PC\Documents\Visual Studio 2015\Projects\BTH3_Bai1\App_Data\Database.mdf';Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.Items["maloai"] == null)
            return;
        //cach1
        String maloai = Context.Items["maloai"].ToString();
        
        
        
        try
        {
            
            string sql = "select * from mathang where maloai = '"+maloai+"'";

            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
            DataTable dt = new DataTable();
            da.Fill(dt);

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }catch(SqlException err)
        {
            Response.Write(err.Message);
        }
       
        
    }
}