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
    String strConnec;
    protected void Page_Load(object sender, EventArgs e)
    {
        strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";

        if (Page.IsPostBack)
        {
            return;
        }

        if (Request.Cookies["tendangnhap"] == null)
        {
            this.Label4.Text = "Bạn phải đăng nhập để xem mặt hàng";
            return;
        }

        if (Context.Items["mahang"] == null)
            return;
        string mahang = Context.Items["mahang"].ToString();
        try
        {
            string sql = "select * from mathang where mathang = '" + mahang + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.DataList2.DataSource = dt;
            this.DataList2.DataBind();


        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button mua = (Button)sender;
        string mahang = mua.CommandArgument.ToString();
        DataListItem item = (DataListItem)mua.Parent;
        string soluong = ((TextBox)item.FindControl("TextBox1")).Text;

        if (Request.Cookies["tendangnhap"] == null)
            return;
        string ten = Request.Cookies["tendangnhap"].Value;
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(strConnec);
            con.Open();
            string query = "select * from donhang where tendangnhap = '" + ten + "' and mahang = '" + mahang + "'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                command = new SqlCommand("update donhang set soluong = soluong+'" + soluong + "' where tendangnhap = '" + ten + "' and mahang = '" + mahang + "'", con);

            }
            else
            {
                reader.Close();
                command = new SqlCommand("insert into donhang(tendangnhap, mahang, soluong) values('" + ten + "', '" + mahang + "', '" + soluong + "')", con);

            }
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Server.Transfer("GioHang.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Server.Transfer("GioHangXoaSua1.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Server.Transfer("GioHangXoaSuaNhieu.aspx");
        

    }

    protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}