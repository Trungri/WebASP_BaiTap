<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        #form1{
            margin-left: 500px;
            margin-top: 100px;
        }

        .style1
        {
            width: 100%;
        }
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            height: 30px;
            width: 187px;
        }
        .auto-style3 {
            width: 187px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" style="text-align: center" class="login" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt">
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />

        </asp:Login>


    
        <br />
        <asp:Label style="margin-right: 550px" ID="Label4" runat="server" Text="Đăng ký"></asp:Label>


    
    </div>


        <table class="style1">
        <tr>
            <td class="auto-style2">
    
                Username</td>
            <td class="auto-style1">
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                *
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="Bạn phải nhập tên đăng nhập"></asp:RequiredFieldValidator>
    
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                *
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="Bạn phải nhập mật khẩu"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
    <asp:Label ID="Label1" runat="server" Text="Retype password"></asp:Label>
            </td>
            <td class="auto-style1">
    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                *
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TextBox2" ControlToValidate="TextBox3" 
        ErrorMessage="Mật khẩu nhập lại không đúng"></asp:CompareValidator>
            </td>
        </tr>
        
    </table>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Sign up" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </form>
</body>
</html>
