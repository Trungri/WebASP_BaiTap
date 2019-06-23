<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MatHangChiTiet-Session.aspx.cs" Inherits="_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            height: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:LinkButton style="font-size: 18px" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Giỏ hàng</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <br />
<script type="text/javascript">
    function ClientValidate(source, arg) {
        if (arg.Value > 0)
            arg.IsValid = true;
        else arg.IsValid = false;
    }
</script>
<asp:DataList ID="DataList2" runat="server">
    <ItemTemplate>
        <table class="auto-style1" align="center">
            <tr>
                <td rowspan="5">
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("mathang") %>' Height="200px" ImageUrl='<%# "~/image/"+Eval("hinh") %>' Width="200px" OnClick="ImageButton1_Click" />
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
                <td class="auto-style3">Số lượng</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                    <asp:CustomValidator ClientValidationFunction="ClientValidate" ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Bạn phải nhập số nguyên và &gt; 0" OnServerValidate="CustomValidator1_ServerValidate1" Display="Dynamic"></asp:CustomValidator>
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

