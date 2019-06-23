using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DangKy : System.Web.UI.Page
{
    string strConnec;
    protected void Page_Load(object sender, EventArgs e)
    {
        strConnec = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Server.MapPath("App_Data/Database.mdf") + "';Integrated Security=True";

        if (Page.IsPostBack)
            return;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
    }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Server.Transfer("Login.aspx");
    }
}