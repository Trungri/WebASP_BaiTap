<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GioHangXoaSuaNhieu.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("mahang") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="tenhang" HeaderText="Tên hàng" />
                <asp:BoundField DataField="mota" HeaderText="Mô tả" />
                <asp:BoundField DataField="dongia" HeaderText="Đơn giá" />
                <asp:TemplateField HeaderText="Số lượng">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("soluong") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;
  
   
&nbsp;
        <br />
        <asp:Button ID="btnXoa" runat="server" Text="Xoá" OnClick="btnXoa_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSua" runat="server" Text="Sửa" OnClick="btnSua_Click" />
  
</asp:Content>

