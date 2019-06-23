using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    //string strConnec;
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
       // strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";

        if (Page.IsPostBack)
            return;
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string ten = this.Login1.UserName;
        string pass = this.Login1.Password;
        string sql = "select * from khachhang where tendangnhap = '" + ten + "' and matkhau = '" + pass + "'";
        

        DataTable table = data.getData(sql);
        
        /*DataTable table = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
            da.Fill(table);
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }*/

        if (table.Rows.Count != 0)
        {
            Response.Cookies["tendangnhap"].Value = ten;
            Server.Transfer("MatHang1.aspx");
        }
        else
        {
            this.Login1.FailureText = "Tên đăng nhập hoặc mật khẩu không đúng! Try again";
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = this.TextBox1.Text.ToString();
        string pass = this.TextBox3.Text.ToString();

        string sql = "insert into khachhang(tendangnhap, matkhau) values ('" + user + "', '" + pass + "')";
        DataTable table = data.getData(sql);
        this.Label3.Text = "Đăng kí thành công";
        /*DataTable table = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
            da.Fill(table);
            this.Label3.Text = "Đăng kí thành công";
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }*/
    }
}