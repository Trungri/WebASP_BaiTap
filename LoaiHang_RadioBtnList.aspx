<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoaiHang_RadioBtnList.aspx.cs" Inherits="LoaiHang_RadioBtnList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
    
        <asp:Label ID="Label1" runat="server" Text="Danh sách loại hàng"></asp:Label>
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" style="text-align: justify" Width="192px" AutoPostBack="True">
        </asp:RadioButtonList>
    
    </div>
    </form>
</body>
</html>
