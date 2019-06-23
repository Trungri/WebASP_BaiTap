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
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        //strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";
        
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
        string sql = "select * from mathang where mathang = '" + mahang + "'";
        dt = data.getData(sql);
        this.DataList2.DataSource = dt;
        this.DataList2.DataBind();


        /*string mahang = Context.Items["mahang"].ToString();
        string sql = "select * from mathang where mathang = '" + mahang + "'";
        
        try
        {
            
            SqlDataAdapter da = new SqlDataAdapter(sql, strConnec);
             dt = new DataTable();
            da.Fill(dt);
            this.DataList2.DataSource = dt;
            this.DataList2.DataBind();


        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }*/

    }
    private void TaoGio()
    {
         dt = new DataTable();
        dt.Columns.Add("mathang");
        dt.Columns.Add("tenhang");
        dt.Columns.Add("mota");
        dt.Columns.Add("soluong");
        dt.Columns.Add("dongia");
        Session["giohang"] = dt;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Server.Transfer("GioHangXoaSua1-Session.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["tendangnhap"] == null)
            return;
        Button mua = (Button)sender;
        string mahang = mua.CommandArgument.ToString();
        DataListItem item = (DataListItem)mua.Parent;
        string soluong = ((TextBox)item.FindControl("TextBox1")).Text;
      
        string tenhang = ((Label)item.FindControl("Label1")).Text;
        string mota = ((Label)item.FindControl("Label2")).Text;
        string dongia = ((Label)item.FindControl("Label3")).Text;
        

        dt = (DataTable)Session["giohang"];
        bool tim = false;
        if (dt == null)
            TaoGio();

        foreach(DataRow dataRow in dt.Rows)
        {
            if(dataRow["mathang"].ToString() == mahang)
            {
                dataRow["soluong"] = Convert.ToUInt32(dataRow["soluong"]) + Convert.ToUInt32(soluong);
                tim = true;
                break; 
            }
        }
        if (!tim)
        {
            DataRow dataRow = dt.NewRow();
            dataRow["mathang"] = mahang;
            dataRow["soluong"] = soluong;
            dataRow["dongia"] = dongia;
            dataRow["tenhang"] = tenhang;
            dataRow["mota"] = mota;

            dt.Rows.Add(dataRow);

        }
        Session["giohang"] = dt;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //try
        //{
        //    int soluong = Convert.ToInt32(args.Value);
        //    if (soluong > 0)
        //        args.IsValid = true;
        //    else
        //        args.IsValid = false;
        //}
        //catch (FormatException ex)
        //{
        //    Response.Write(ex.Message);
        //    args.IsValid = false;
        //}
    }

    protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
    {
        try
        {
            int soluong = Convert.ToInt32(args.Value);
            if (soluong > 0) args.IsValid = true;
            else args.IsValid = false;
        }
        catch (FormatException ex)
        {
            args.IsValid = false;
        }
    }
}