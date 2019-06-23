<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoaiHang.aspx.cs" Inherits="LoaiHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("maloai") %>' Height="200px" ImageUrl='<%# "~/image/" + Eval("hinh") %>' Width="200px" OnClick="ImageButton1_Click" />
                <br />
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Eval("tenloai") %>' CommandArgument='<%# Eval("maloai") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
