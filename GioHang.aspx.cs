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
    // String strConnec;
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        //strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";
       

        if (Request.Cookies["tendangnhap"] == null)
        {
            this.Label1.Text = "Bạn phải đăng nhập để xem mặt hàng";
            return;
        }
        string ten = Request.Cookies["tendangnhap"].Value;

        string q = "select donhang.mahang, tenhang, mota, dongia, soluong, soluong*dongia as thanhtien from donhang, mathang where mathang.mathang = donhang.mahang and tendangnhap = '" + ten + "'";
        DataTable dt = data.getData(q);
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
        double tong = 0;

        foreach (DataRow row in dt.Rows)
        {
            double thanhTien = Convert.ToDouble(row["thanhtien"]);
            tong += thanhTien;
        }
        this.Label1.Text = "Tổng thành tiền : " + tong + " đồng";

        /*try
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
            }

            //for(int i = 0; i < dt.Rows.Count; i++)
            //{
            //    double thanhTien = Convert.ToDouble(dt.Rows[i]["thanhtien"]);
            //    tong += thanhTien;
            //}
            this.Label1.Text = "Tổng thành tiền : " + tong + " đồng";

        }catch(SqlException ex)
        {
            Response.Write(ex.Message);
        }*/
    }
}