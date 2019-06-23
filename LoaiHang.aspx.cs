using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class LoaiHang : System.Web.UI.Page
{
    string strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\PC\Documents\Visual Studio 2015\Projects\BTH3_Bai1\App_Data\Database.mdf';Integrated Security=True";
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;
        
        string sql = "select * from loaihang";
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
            DataTable dt = new DataTable();
            da.Fill(dt);

             this.DataList1.DataSource = dt;
             this.DataList1.DataBind();
        }catch(SqlException err)
        {
            Response.Write(err.Message);
        }

        
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string maloai = ((ImageButton)sender).CommandArgument;
        Context.Items["maloai"] = maloai;
        Server.Transfer("MatHang.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string maloai = ((LinkButton)sender).CommandArgument;
        Context.Items["maloai"] = maloai;
        Server.Transfer("MatHang.aspx");
    }



    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}