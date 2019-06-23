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
            foreach(DataRow row in dt.Rows)
            {
                double thanhTien = Convert.ToDouble(row["thanhtien"]);
                tong += thanhTien;
            }
            this.Label1.Text = "Tổng thành tiền : " + tong + " đồng";
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["tendangnhap"] == null)
        {
            return;
        }
        string ten = Request.Cookies["tendangnhap"].Value;
        foreach(GridViewRow row in this.GridView1.Rows)
        {
            if (((CheckBox)row.FindControl("CheckBox1")).Checked)
            {
                string mahang = ((HiddenField)row.FindControl("HiddenField1")).Value;
                string sql = "delete from donhang where mahang = '" + mahang + "' and tendangnhap = '" + ten + "'";
                SqlConnection con = new SqlConnection(strConnec);
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Response.Write(err.Message);
                }
                finally
                {
                    con.Close();
                }
               
            }
        }
        this.docDL();
    }

    protected void btnSua_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["tendangnhap"] == null)
        {
            return;
        }
        string ten = Request.Cookies["tendangnhap"].Value;
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            if (((CheckBox)row.FindControl("CheckBox1")).Checked)
            {
                string mahang = ((HiddenField)row.FindControl("HiddenField1")).Value;
                string soluong = ((TextBox)row.FindControl("TextBox1")).Text;
                string sql = "update donhang set soluong = '" + soluong + "' where mahang = '" + mahang + "' and tendangnhap = '" + ten + "'";

                SqlConnection con = new SqlConnection(strConnec);
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Response.Write(err.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }
        this.docDL();
     }
}