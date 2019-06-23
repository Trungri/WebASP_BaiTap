<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MatHangChiTiet.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Giỏ hàng</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Giỏ hàng XOÁ SỬA 1</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Giỏ hàng XOÁ SỬA NHIỀU</asp:LinkButton>
<br />
<asp:DataList ID="DataList2" runat="server" OnSelectedIndexChanged="DataList2_SelectedIndexChanged">
    <ItemTemplate>
        <table class="auto-style1">
            <tr>
                <td rowspan="5">
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("mathang") %>' Height="100px" ImageUrl='<%# "~/image/"+Eval("hinh") %>' Width="100px" />
                </td>
                <td>Tên hàng</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("tenhang") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Mô tả</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("mota") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Đơn giá</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("dongia") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Số lượng</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mua" CommandArgument='<%# Eval("mathang") %>' />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
    <asp:Label ID="Label4" runat="server"></asp:Label>
    <br />
<br />
</asp:Content>

