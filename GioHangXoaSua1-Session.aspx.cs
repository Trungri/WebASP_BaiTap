using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;
        this.docDL();


    }
    private void docDL()
    {
        DataTable dt = (DataTable)Session["giohang"];
        if (dt == null)
            return;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        double tong = 0;

        for(int i = 0; i < dt.Rows.Count; i++)
        {
            double thanhTien = Convert.ToDouble(dt.Rows[i]["soluong"]) * Convert.ToDouble(dt.Rows[i]["dongia"]);
            tong += thanhTien;
        }

        //  String kq = Convert.ToString(tong);
        //String.Format("{0:0,0}", kq);
        this.Label1.Text = "Tổng thành tiền : " + tong + " đồng";

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable dt = (DataTable)Session["giohang"];

        if(e.CommandName == "Sua")
        {
            GridViewRow row = (GridViewRow)((Button)e.CommandSource).Parent.Parent;
            string mahang = ((Button)e.CommandSource).CommandArgument;
            string soluong = ((TextBox)row.FindControl("TextBox1")).Text;
            dt.Rows[row.DataItemIndex]["soluong"] = soluong;
            Session["giohang"] = dt;
        }else if(e.CommandName == "Xoa")
        { 
            GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
            string mahang = ((LinkButton)e.CommandSource).CommandArgument;
            dt.Rows[row.DataItemIndex].Delete();
            Session["giohang"] = dt;
        }
        this.docDL();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
}