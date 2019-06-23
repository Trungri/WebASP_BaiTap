using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class LoaiHang_RadioBtnList : System.Web.UI.Page
{
    string strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\PC\Documents\Visual Studio 2015\Projects\BTH3_Bai1\App_Data\Database.mdf';Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select * from loaihang";
        SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
        DataTable dt = new DataTable();
        da.Fill(dt);

        this.RadioButtonList1.DataSource = dt;
        this.RadioButtonList1.DataTextField = "tenloai";
        this.RadioButtonList1.DataValueField = "maloai"; 
        this.RadioButtonList1.DataBind();
        
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string maLoai = this.RadioButtonList1.SelectedItem.Value;
        Context.Items["maloai"] = maLoai;
        Server.Transfer("MatHang.aspx");

        //cach 2
       // Server.Transfer("MatHang.aspx?maloai=" + this.RadioButtonList1.SelectedItem.Value);
    }
}