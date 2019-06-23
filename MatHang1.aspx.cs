using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    //String strConnec;

    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        //strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='"+Server.MapPath("App_Data/Database.mdf")+"';Integrated Security=True";
        if (Page.IsPostBack)
            return;

        string sql;
        if (Request.QueryString["ml"] == null)
        {
            sql = "select * from mathang";
        }
        else
        {
            string maloai = Request.QueryString["ml"];
            sql = "select * from mathang where maloai = '" + maloai + "'";

        }
        DataTable dt = data.getData(sql);
        this.DataList2.DataSource = dt;
        this.DataList2.DataBind();

        /*
        string sql;
        if(Context.Items["maloai"] == null)
        {
            sql = "select * from mathang";
        }else
        {
            string maloai = Context.Items["maloai"].ToString();
            sql = "select * from mathang where maloai = '" + maloai + "'";

        }
        try
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.DataList2.DataSource = dt;
            this.DataList2.DataBind();
            //DataSet ds = new DataSet();

        }
        catch (SqlException err)
        {
            Response.Write(err.Message);
        }*/
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string mahang = ((LinkButton)sender).CommandArgument;
        Context.Items["mahang"] = mahang;
        Server.Transfer("MatHangChiTiet-Session.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string mahang = ((ImageButton)sender).CommandArgument;
        Context.Items["mahang"] = mahang;
        Server.Transfer("MatHangChiTiet-Session.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string mahang = ((LinkButton)sender).CommandArgument;
        Context.Items["mahang"] = mahang;
        Server.Transfer("MatHangChiTiet-Session.aspx");
    }

    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}