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
        if(Request.Cookies["tendangnhap"] == null)
        {
            return;
        }
        this.docDL();
    }

    private void docDL()
    {
        string ten = Request.Cookies["tendangnhap"].Value;
        try
        {
            string q = "select donhang.mahang, tenhang, mota, dongia, soluong, soluong*dongia as thanhtien from donhang, mathang where mathang.mathang = donhang.mahang and tendangnhap = '" + ten + "'";
            SqlDataAdapter da = new SqlDataAdapter(q, strConnec);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

            double tong = 0;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                double thanhTien = Convert.ToDouble(dt.Rows[i]["thanhtien"]);
                tong += thanhTien;
            }
            this.Label1.Text = "Tổng thành tiền : " + tong + " đồng";
        }catch(SqlException ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if(Request.Cookies["tendangnhap"] == null)
        {
            return;
        }
        string ten = Request.Cookies["tendangnhap"].Value;
        string mahang = ((LinkButton)sender).CommandArgument;
        string sql = "delete from donhang where mahang = '" + mahang + "' and tendangnhap = '" + ten + "'";
        SqlConnection con = new SqlConnection(strConnec);
        try
        {
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
        }catch(SqlException err)
        {
            Response.Write(err.Message);
        }
        finally
        {
            con.Close();
        }
        this.docDL();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Request.Cookies["tendangnhap"] == null)
        {
            return;
        }
        Button sua = (Button)sender;
        string mahang = sua.CommandArgument;
        GridViewRow item = (GridViewRow)sua.Parent.Parent;
        string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
        string ten = Request.Cookies["tendangnhap"].Value;
        SqlConnection con = new SqlConnection(strConnec);
        String sql = "update donhang set soluong = '" + soluong + "' where tendangnhap = '" + ten + "' and mahang = '" + mahang + "'";
        try
        {
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
        }catch(SqlException err)
        {
            Response.Write(err.Message);
        }
        finally
        {
            con.Close();
        }
        this.docDL();


    }
}