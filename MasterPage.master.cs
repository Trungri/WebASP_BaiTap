using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    // string strConnec;

    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        // strConnec =@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";
        
        
        if (Page.IsPostBack)
            return;
        if (Request.Cookies["tendangnhap"] != null)
        {
            this.Label1.Text = Request.Cookies["tendangnhap"].Value;
        }
        string sql = "select * from loaihang";
        DataTable dt = data.getData(sql);
        this.DataList1.DataSource = dt;
        this.DataList1.DataBind();


        /*
        try
        {
            if(Request.Cookies["tendangnhap"] != null)
            {
                this.Label1.Text = Request.Cookies["tendangnhap"].Value;
            }
            

            string sql = "select * from loaihang";

            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.DataList1.DataSource = dt;
            this.DataList1.DataBind();

            //DataSet ds = new DataSet();

        }
        catch (SqlException err)
        {
            Response.Write(err.Message);
        }*/
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string maloai = ((LinkButton)sender).CommandArgument;
        /*Context.Items["maloai"] = maloai;
        Server.Transfer("MatHang1.aspx");*/
        Response.Redirect("MatHang1.aspx?ml=" + maloai);
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
       
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //  Server.Transfer("MatHang1.aspx");
        Response.Redirect("MatHang1.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //Request.Cookies["tendangnhap"].Value = null;
        Session.Abandon();
        Server.Transfer("Login.aspx");
    }
}
